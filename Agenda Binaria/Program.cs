using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace Agenda_Binaria
{
    class Program
    {
        public static int NRegistros = 0;
        //  public static string bintemp;
        public static int caf;
        public static string te;
        public static string[,] MatrTemp = new string[100, 10];
        public static string[] pregu = { "CODIGO", "Nombre", "Edad","Genero" ,"Documento de Identidad",
                                           "Fecha de Nacimiento Dia","Fecha de Nacimiento Mes","Fecha de Nacimiento Año","Lugar de Nacimiento","Lugar de Residencia"};
        public static int[] tm = { 2, 11, 3, 11, 2 };
        static void Main(string[] args)
        {
            bool cerrar = false;

            do
            {

                MENUA();
                int opcion;
                while (!int.TryParse(Console.ReadLine(), out opcion)) { MENUA(); }
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        AGREGAR();
                        Console.ReadKey();
                        break;
                    case 2:
                        Editar();
                        break;
                    case 3:
                        Console.Clear();
                        Visualizar();
                        Eliminar();
                        break;
                    case 4:
                        Visualizar();
                        Console.ReadKey();
                        break;
                    case 5:
                        string mes_actual = Convert.ToString(DateTime.Now.Month);
                        int diaA = Convert.ToInt16(DateTime.Now.Day);
                        string[] vectna = new string[100];
                        string[] vectnC = new string[100];
                        int c = 0;
                        int cu = 0;
                        Visualizar();
                        Console.Clear();

                        for (int i = 0; i < caf; i++)
                        {
                            if (MatrTemp[i, 6] == mes_actual && Convert.ToInt16(MatrTemp[i, 5]) <= diaA) { vectna[c] = MatrTemp[i, 1] + " " + MatrTemp[i, 5] + "/" + MatrTemp[i, 6] + "/" + MatrTemp[i, 7]; c++; }
                            else
                                if (MatrTemp[i, 6] == mes_actual && Convert.ToInt16(MatrTemp[i, 5]) >= diaA)
                            {
                                vectnC[cu] = MatrTemp[i, 1] + " " + MatrTemp[i, 5] + "/" + MatrTemp[i, 6] + "/" + MatrTemp[i, 7]; cu++;
                            }
                        }
                        Console.WriteLine("ESTAS PERSONAS YA CUMPLIARON AÑO ESTE MES");
                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int i = 0; i < c; i++)
                        {
                            Console.WriteLine(vectna[i]);
                        }
                        Console.ResetColor();
                        Console.WriteLine("ESTAS PERSONAS CUMPLIRAN AÑO ESTE MES");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        for (int i = 0; i < cu; i++)
                        {
                            Console.WriteLine(vectnC[i]);
                        }
                        Console.ReadKey();
                        break;
                    case 6:
                        cerrar = true;
                        break;
                }



            } while (cerrar == false);
        }
        public static void DiseñoConsola()
        {
            Console.Title = "»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»AGENDA ELECTRÓNICA BINARIA«««««««««««««««««««««««««««««««««««««";
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

        }
        public static void DiseñoConsola_ALT()
        {
            Console.Title = "»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»AGENDA ELECTRÓNICA BINARIA«««««««««««««««««««««««««««««««««««««";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

        }
        public static void MenuInicio()
        {
            try
            {
                bool cerrar = false;
                do
                {
                    MI();
                    int opc1;
                    Console.SetCursorPosition(55, 6);
                    while (!int.TryParse(Console.ReadLine(), out opc1))
                    {
                        MI();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(15, 6);
                        Console.Write("ERROR INGRESE UN NUMERO DE OPCION");
                        Console.ResetColor();
                        Console.SetCursorPosition(55, 6);
                    }

                    switch (opc1)
                    {
                        case 1:
                            Menu_Administracion();
                            //  Console.ReadKey();
                            break;
                        case 2:
                            Visualizar();
                            Console.ReadKey();
                            break;
                        case 4:

                            Salir();
                            cerrar = true;

                            break;

                    }
                } while (cerrar == false);

            }
            catch (Exception ex) { ex.ToString(); }
        }
        public static void MI()
        {
            Console.Clear();
            Console.SetCursorPosition(50, 0);
            Console.Write("MENÚ PRINCIPAL");
            Console.SetCursorPosition(45, 1);
            Console.Write("[1].ADMINISTRACIÓN");
            Console.SetCursorPosition(45, 2);
            Console.Write("[2].VISUALIZACIÓN");
            Console.SetCursorPosition(45, 3);
            Console.Write("[3].ESTADÍSTICAS");
            Console.SetCursorPosition(45, 4);
            Console.Write("[4].CERRAR PROGRAMA");
            Console.SetCursorPosition(57, 6);
            Console.Write("█");
            Console.SetCursorPosition(54, 7);
            Console.Write("▀▀▀▀");
            Console.SetCursorPosition(54, 5);
            Console.Write("▄▄▄▄");
            Console.SetCursorPosition(54, 6);
            Console.Write("█");

        }
        public static void Salir()
        {
            Console.Clear();
            Console.WriteLine("ADIOS :)");
            Thread.Sleep(1000);
        }
        public static void MENUA()
        {
            Console.Clear();
            Console.SetCursorPosition(50, 0);
            Console.Write("AGENDA ELECTRONICA");
            Console.SetCursorPosition(45, 1);
            Console.Write("[1].AGREGAR");
            Console.SetCursorPosition(45, 2);
            Console.Write("[2].EDITAR");
            Console.SetCursorPosition(45, 3);
            Console.Write("[3].ELIMINAR");
            Console.SetCursorPosition(45, 4);
            Console.Write("[4].MOSTRAR ");
            Console.SetCursorPosition(45, 5);
            Console.Write("[5].LISTAS ");
            Console.SetCursorPosition(45, 6);
            Console.Write("[6].SALIR ");

            Console.SetCursorPosition(57, 9);
            Console.Write("█");
            Console.SetCursorPosition(54, 10);
            Console.Write("▀▀▀▀");
            Console.SetCursorPosition(54, 8);
            Console.Write("▄▄▄▄");
            Console.SetCursorPosition(54, 9);
            Console.Write("█");
        }
        public static void Menu_Administracion()
        {
            try
            {
                MENUA();
                int opc1;
                Console.SetCursorPosition(55, 6);
                while (!int.TryParse(Console.ReadLine(), out opc1))
                {
                    MENUA();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(15, 6);
                    Console.Write("ERROR INGRESE UN NUMERO DE OPCION");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(55, 6);
                }

                switch (opc1)
                {
                    case 1:

                        AGREGAR();
                        Console.ReadKey();

                        break;
                    case 2:
                        Editar();

                        break;
                    case 3:
                        Eliminar();
                        break;




                }
            }
            catch (Exception ex) { ex.ToString(); }

        }
        public static void AGREGAR()
        {

            string n = "fichero.bin";
            if (SiestaVacio(n) == false)
            {

                Aumento();
                ADD_M();
            }
            else
            {



                ADD_N();


            }

        }
        public static void ADD_N()
        {
            string prueba = " ";
            FileStream fs = new FileStream("fichero.bin", FileMode.Open);
            BinaryWriter binWriter = new BinaryWriter(fs, Encoding.ASCII);
            binWriter.Write("1;");
            for (int i = 1; i < 10; i++)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Escriba su " + pregu[i]);
                Console.SetCursorPosition(0, 1);
                prueba = Console.ReadLine();
                binWriter.Write(prueba);
                binWriter.Write(";");
                Console.ReadKey();
            }
            binWriter.Close();
            //   NRegistros=1;

            //string vector_nuevo = prueba;
            //String[] elements = vector_nuevo.Split(';');
            //for (int i = 0; i < 10; i++) { MatrTemp[0, i] = elements[i]; }
            //binWriter.Write(NRegistros + ";" );
            //NRegistros++;
            //for (int i = 1; i < 10; i++) { binWriter.Write( elements[i]+";"); }
            //binWriter.Close();
            //Console.ReadLine();
        }
        public static void ADD_M()
        {

            //string[] respues = new string[10];
            //string prueba = NRegistros.ToString();
            //respues[0] = prueba + ";";
            //for (int i = 1; i < 10; i++)
            //{
            //    Console.Clear();
            //    Console.SetCursorPosition(0, 0);
            //    Console.WriteLine("Escriba su " + pregu[i]);
            //    Console.SetCursorPosition(0, 1);
            //    prueba = Console.ReadLine() + ";";
            //    respues[i] = prueba;


            //}

            //string d = " ";
            //foreach (string w in respues) { d = d + w; }


            //NRegistros++;
            //return d.TrimStart();
            //string prueba = " ";
            //for (int i = 1; i < 10; i++)
            //{
            //    Console.Clear();
            //    Console.SetCursorPosition(0, 0);
            //    Console.WriteLine("Escriba su " + pregu[i]);
            //    Console.SetCursorPosition(0, 1);
            //    prueba = prueba + Console.ReadLine() + ";";
            //    Console.ReadKey();
            //}
            Aumento();
            string prueba = null;
            FileStream fs = new FileStream("fichero.bin", FileMode.Append);
            BinaryWriter binWriter = new BinaryWriter(fs, Encoding.ASCII);

            //    NRegistros=NRegistros-1;
            Console.Write(NRegistros);
            Console.ReadKey();
            binWriter.Write(NRegistros.ToString());
            binWriter.Write(";");
            for (int i = 1; i < 10; i++)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Escriba su " + pregu[i]);
                Console.SetCursorPosition(0, 1);
                prueba = Console.ReadLine();
                binWriter.Write(prueba);
                binWriter.Write(";");
                Console.ReadKey();
            }
            binWriter.Close();
            //  NRegistros++;


            //FileStream fs = new FileStream("fichero.bin", FileMode.Append);
            //BinaryWriter binWriter = new BinaryWriter(fs, Encoding.ASCII);
            //string vector_nuevo = prueba;
            //String[] elements = vector_nuevo.Split(';');
            //for (int i = 0; i < 10; i++) { MatrTemp[0, i] = elements[i]; }
            //binWriter.Write(NRegistros + ";");
            //NRegistros++;
            //for (int i = 1; i < 10; i++) { binWriter.Write(elements[i] + ";"); }
            //binWriter.Close();
            //Console.ReadLine();


        }
        public static bool SiestaVacio(string ruta)
        {


            byte unDato;
            FileStream fichero;
            fichero = File.Open(ruta, FileMode.OpenOrCreate);
            fichero.Position = 0;

            unDato = (byte)fichero.ReadByte();

            if (unDato == 255)
            {
                fichero.Close();
                return true;
            }
            fichero.Close();
            return false;
        }
        public static string devolver(string ruta)
        {
            FileStream fichero = File.OpenRead(ruta);
            string f = " ";
            for (int pos = 0; pos < fichero.Length; pos++)
            {
                byte unDato = (byte)fichero.ReadByte();
                if (unDato <= 47) { }
                else
                {
                    char letra = Convert.ToChar(unDato);
                    f = f + letra.ToString();
                }
            }
            fichero.Close();
            return f.TrimStart();
        }
        public static void Aumento()
        {
            te = devolver("fichero.bin");
            String[] elements = te.Split(';');
            caf = elements.Length / 10;
            NRegistros = caf + 1;
        }
        public static void Copiar()
        {
            Aumento();

            te = devolver("fichero.bin");
            String[] elements = te.Split(';');

            NRegistros = caf + 1;
            int o = 0;
            int posfil = 0;
            while (posfil < caf && o != elements.Length)
            {
                for (int col = 0; col < 10; col++)
                {
                    MatrTemp[posfil, col] = elements[o];

                    o++;
                }
                posfil++;
            }
        }
        public static void Editar()
        {
            Visualizar();
            Copiar();
            bool encontrar = false;
            Console.WriteLine("Ingrese el CODIGO de la persona a editar");
            int cod = int.Parse(Console.ReadLine());
            int pf = 0;

            for (int fr = 0; fr < caf; fr++)
            {



                if (cod == Convert.ToInt16(MatrTemp[fr, 0])) { pf = fr; encontrar = true; }



            }
            if (encontrar == true)
            {
                bool salir = false;
                do
                {
                    Console.WriteLine("Seleccione el valor a Editar");
                    for (int u = 1; u < pregu.Length; u++)
                    {
                        Console.WriteLine(u + "[" + pregu[u] + "]");
                    }
                    Console.WriteLine("11[SALIR]");
                    int e = int.Parse(Console.ReadLine());
                    Console.WriteLine("ESCRIBA EL NUEVO {0}", pregu[e]);
                    switch (e)
                    {
                        case 1:
                            MatrTemp[pf, e] = Console.ReadLine();
                            Actualizar();
                            salir = true;
                            break;
                        case 2:
                            MatrTemp[pf, e] = Console.ReadLine();
                            Actualizar();
                            salir = true;
                            break;
                        case 3:
                            MatrTemp[pf, e] = Console.ReadLine();
                            Actualizar();
                            salir = true;
                            break;
                        case 4:
                            MatrTemp[pf, e] = Console.ReadLine();
                            Actualizar();
                            salir = true;
                            break;
                        case 5:
                            MatrTemp[pf, e] = Console.ReadLine();
                            Actualizar();
                            salir = true;
                            break;
                        case 6:
                            MatrTemp[pf, e] = Console.ReadLine();
                            Actualizar();
                            salir = true;
                            break;
                        case 7:
                            MatrTemp[pf, e] = Console.ReadLine();
                            Actualizar();
                            salir = true;
                            break;
                        case 8:
                            MatrTemp[pf, e] = Console.ReadLine();
                            Actualizar();
                            salir = true;
                            break;
                        case 9:
                            MatrTemp[pf, e] = Console.ReadLine();
                            Actualizar();
                            salir = true;
                            break;
                        case 11: salir = true; break;
                    }
                } while (salir == false);
            }

            else { Console.Write("NO SE ENCONTRO"); }


        }
        public static void Actualizar()
        {
            FileStream fhw = new FileStream("q.bin", FileMode.CreateNew);
            fhw.Close();
            FileStream fh = new FileStream("q.bin", FileMode.Open);
            BinaryWriter binWr = new BinaryWriter(fh, Encoding.ASCII);

            for (int fr = 0; fr < caf; fr++)
            {
                for (int colr = 0; colr < 10; colr++)
                {

                    binWr.Write(MatrTemp[fr, colr]);
                    binWr.Write(";");
                }
            }
            binWr.Close();
            File.Delete("fichero.bin");
            File.Copy("q.bin", "fichero.bin");
            File.Delete("q.bin");
        }
        public static void Visualizar()
        {
            Console.Clear();
            Copiar();
            for (int fr = 0; fr < caf; fr++)
            {
                for (int colr = 0; colr < 10; colr++)
                {

                    Console.SetCursorPosition(colr * 12, fr);
                    Console.WriteLine(MatrTemp[fr, colr]);

                }

            }
        }
        static void VaciarMatriz()
        {
            Console.WriteLine(caf);
            for (int fr = 0; fr < caf + 1; fr++)
            {
                for (int colr = 0; colr < MatrTemp.GetLength(1); colr++)
                {

                    MatrTemp[fr, colr] = null;

                }

            }
        }
        public static void Eliminar()
        {
            Copiar();
            string[,] matrreu = new string[100, 10];
            caf--;
            Console.WriteLine("Ingrese el codigo de la persona a eliminar");
            int cod = int.Parse(Console.ReadLine());
            if (cod == 1)
            {
                Console.Clear();
                for (int fr = 0; fr < caf; fr++)
                {
                    for (int colr = 1; colr < 10; colr++)
                    {

                        matrreu[fr, 0] = MatrTemp[fr, 0];
                        matrreu[fr, colr] = MatrTemp[fr + 1, colr];
                    }

                }

                for (int fr = 0; fr < caf; fr++)
                {
                    for (int colr = 0; colr < MatrTemp.GetLength(1); colr++)
                    {

                        Console.SetCursorPosition(colr * 11, fr);
                        Console.WriteLine(matrreu[fr, colr]);

                    }

                }
            }
            else if
                (cod == 2)
            {
                for (int fr = 0; fr <= 0; fr++)
                {
                    for (int colr = 0; colr < 10; colr++)
                    {

                        matrreu[fr, colr] = MatrTemp[fr, colr];
                    }

                }
                for (int fr = 1; fr <= caf; fr++)
                {
                    for (int colr = 1; colr < 10; colr++)
                    {
                        matrreu[fr, 0] = Convert.ToString(fr + 1);
                        matrreu[fr, colr] = MatrTemp[fr + 1, colr];
                    }

                }
            }


            Console.ReadKey();



            Console.Clear();
            for (int fr = 0; fr <= cod - 2; fr++)
            {
                for (int colr = 0; colr < 10; colr++)
                {

                    matrreu[fr, colr] = MatrTemp[fr, colr];
                }

            }
            for (int fr = cod - 1; fr <= caf; fr++)
            {
                for (int colr = 1; colr < 10; colr++)
                {
                    matrreu[fr, 0] = Convert.ToString(fr + 1);
                    matrreu[fr, colr] = MatrTemp[fr + 1, colr];
                }

            }

            Console.ReadKey();
            VaciarMatriz();

            for (int fr = 0; fr < caf; fr++)
            {
                for (int colr = 0; colr < MatrTemp.GetLength(1); colr++)
                {

                    MatrTemp[fr, colr] = matrreu[fr, colr];

                }

            }

            Actualizar();



        }
    }
}
