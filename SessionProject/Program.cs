using System;

namespace SessionProject
{
    class Program
    {
        
        static Session session = new Session();
        static Boolean isAdmin = false;


        static void Main(string[] args)
        {
            Console.WriteLine("INICIO DE SESSION");
            login();

        }


        static void menus()
        {
            String option = Console.ReadLine();
            option = option.ToLower();
            String fileName = "";
            String text = "";
            Boolean exit = false;
            if (isAdmin)
            {
                switch (option)
                {
                    case "a":
                        Console.WriteLine("Agregar crendenciales.");
                        Console.WriteLine("Ingrese el usuario: ");
                        String username = Console.ReadLine();
                        Console.WriteLine("Ingrese la contraseña: ");
                        String paasword = Console.ReadLine();
                        session.addCredential(username, paasword);
                        break;
                    case "b":
                        Console.WriteLine("Crear archivo");
                        Console.WriteLine("Nombre del archivo? ");
                        fileName = Console.ReadLine();
                        Console.WriteLine("Ingrese el texto del archivo");
                        text = Console.ReadLine();
                        session.newFile(fileName);
                        session.addTextFile(text, fileName);
                        break;
                    case "c":
                        Console.WriteLine("Borrar archivo");
                        Console.WriteLine("Nombre del archivo? ");
                        fileName = Console.ReadLine();
                        session.deleteFile(fileName);
                        break;
                    case "d":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opcion ingresada incorrecta");

                        break;

                }
                if (!exit)
                {
                    printMenuAdmin();
                    menus();
                }
            }
            else
            {
                switch (option)
                {
                    case "a":
                        Console.WriteLine("NOMBRE DE ARCHIVOS .txt");
                        Console.WriteLine("ReneAlexanderAraujoSotoSMIS060720.txt");
                        Console.WriteLine("JonathanEliaGamezLarinSMIS017821.txt");
                        Console.WriteLine("PlacidoIsmaelLunaArguetaSMIS071121.txt");
                        Console.WriteLine("AlexisManuelCalixMagañaSMIS021821.txt");
                        Console.WriteLine("Introduce el nombre del archivo que quiereas leer incluyendo el txt al final.");
                        Console.WriteLine("Nombre del archivo: ");
                        fileName = Console.ReadLine();
                        text = session.readFile(fileName);
                        Console.WriteLine(text);
                        break;
                    case "b":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opcion ingresada incorrecta");

                        break;

                }
                if (!exit)
                {
                    printMenuOther();
                    menus();
                }
            }
        }

        static void login()
        {

            
           var contador = 1;
            Console.WriteLine("Ingrese usuario?");
            String username = Console.ReadLine();
            Console.WriteLine("Ingrese contraseña?");
            String password = Console.ReadLine();
            if (session.login(username, password))
            {
                if (username.Equals("admin"))
                {
                    isAdmin = true;
                    printMenuAdmin();
                }
                else
                {
                    isAdmin = false;
                    printMenuOther();
                }

                menus();
            }
            else
            {
                Console.WriteLine("Usuario o contraseña incorrectos");
                contador = contador + 1;
                login();
            }

        }

        static void printMenuAdmin()
        {
            Console.WriteLine("--------------- MENU ADMINISTRADOR--------------");
            Console.WriteLine("\ta. Registrar nuevo usuario");
            Console.WriteLine("\tb. Crear archivo");
            Console.WriteLine("\tc. Borrar archivo");
            Console.WriteLine("\td. Salir:");

        }

        static void printMenuOther()
        {
            Console.WriteLine("--------------- MENU ADMINISTRADOR--------------");
            Console.WriteLine("\ta. Leer Archivo");
            Console.WriteLine("\tb. Salir:");

        }
    }
}
