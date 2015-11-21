using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenFileDialog_WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String[] seleccion = { "Ningun", "Por Imagen", "Por texto", "Por video" }; //filtro de interfaz
        String[] filtro = { "","Todas las imagenes|*jpg;*png;*bmp|JPG|*jpg|PNG|*png|BMP|*bmp",
                                "Todos los textos|*txt;*doc;*docx;*xls|TXT|*txt|DOC|*doc;*docx|XLS|*xls",
                                "Todos los videos|*mp4;*avi;*mpeg;*mov;*wmv;*flv|MP4|*mp4|AVI|*avi|MPEG|*mpeg|MOV|*mov|WMV|*wmv|FLV|*flv"                                
                               };//filtros reales

        public MainWindow()
        {
            InitializeComponent();            

            filtro1.ItemsSource= seleccion;     //se llena el combobox 1 con los filtros de interfas
            filtro2.ItemsSource = seleccion;    //se llema el combobox 2 con los filtros de interfas
            filtro1.SelectedIndex = 0;          //se inicializa el combobox 1 en el item 1
            filtro2.SelectedIndex = 0;          //se inicializa el combobox 2 en el item 1
        }

        private void btn_dlg_UN_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg1 = new OpenFileDialog(); //se crea una instancia de dialogo
            dlg1.Title = "Seleccion un elemento";       //Aplica un titulo al dialogo
            dlg1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//un destino defaul 
            int el_filtro = filtro1.SelectedIndex;      //se obtiene el index del filtro a aplicar

            if (el_filtro != 0) //si se aplico algun filtro
                dlg1.Filter = filtro[el_filtro];    //setear cadena de filtro real
            
            //Console.WriteLine("Aplicando filtro"+ filtro[el_filtro]);//
            if (dlg1.ShowDialog() == true) {    //abrir el dialogo
                this.txt_UN.AppendText(dlg1.FileName);  //agregar al ruta al richText de abajo
            }
        }

        private void btn_dlg_MUL_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg2 = new OpenFileDialog(); //se crea una instancia de dialogo
            dlg2.Multiselect = true;                    //se aplica opcion de multiselecion de archivos
            dlg2.Title = "Seleccione multiples elementos";//Aplica un titulo al dialogo
            dlg2.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//un destino defaul

            int el_filtro = filtro2.SelectedIndex;      //se obtiene el index del filtro a aplicar

            if (el_filtro != 0)     //si se aplico algun filtro
                dlg2.Filter = filtro[el_filtro];    //setear cadena de filtro real
            //Console.WriteLine("Aplicando filtro"+ filtro[el_filtro]);//
            /*Si lo utilizas con Windows Form el if condicional se cambia por
                if(dlg2.ShowDialog() == DialogResult.OK){}
            */
            if (dlg2.ShowDialog() == true)  //se abre dialogo
            {
                foreach (String s in dlg2.FileNames)//recorre el arreglo de elementos
                {
                    String nombre = System.IO.Path.GetFileNameWithoutExtension(s); // se parcea el nombre del archivo sin extencion
                    this.txt_MUL.AppendText(string.Format("\n---\nNombre:{0}\nRuta:{1}",nombre,s));//se agrega al richtext el nombre y ruta absoluta de los
                                                                                                   //archivios seleccionados.
                }
            }
        }
    }
}
