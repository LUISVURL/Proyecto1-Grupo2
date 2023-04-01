using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Se declararon la mayoria de las variables al inicio del programa para evitar estar declarandolas como
               publicas en cada sección*/
            string CicloPrincipal = "S",CicloFacturacion="S";
            string nombre, nit, correo,opcionpago;
            double multiplicacion = 0, total = 0, multiplicacionf = 0;
            double total001 = 0, total002 = 0, total003 = 0, total004 = 0, total005 = 0;
            int C001 = 0, C002 = 0, C003 = 0, C004 = 0, C005 = 0;
            int CF001 = 0, CF002 = 0, CF003 = 0, CF004 = 0, CF005 = 0;
            int numerofactura = 1;
            int puntostotales = 0, puntos = 0;
            // en esta parte inicia el ciclo del menú principal
            do
            {
                /*En las primeras tres lineas se establece el nombre de la consola, el color de la letra y el color del fondo*/
                Console.Title = "TIENDA MAS - URL";
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("|      TIENDA MAS - URL      |");
                Console.WriteLine("------------------------------");
                Console.WriteLine("| 1. Facturación             |");
                Console.WriteLine("| 2. Reportes de Facturación |");
                Console.WriteLine("| 3. Salir                   |");
                Console.WriteLine("------------------------------");
                Console.Beep();
                Console.Write("\n Ingrese número de opción: ");
                // Para ingresar la opción del menú se utilizó un switch que contiene directamente el Console.ReadLine();
                switch (Console.ReadLine())
                {
                    // El case "1" es la opción de facturación
                    case "1":
                        // La variable fecha almacena la fecha en ese momento en el formato "DD-MM-YYYY"
                        string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                        /* Debido a que el ciclo de facturación se puede repetir en varias ocaciones es necesario
                           resetear todos los contadores a 0 y nos aseguramos tambien de limpiar las variables que
                           se solicitan mas adelante */
                        CF001 = 0; CF002 = 0; CF003 = 0; CF004 = 0; CF005 = 0;
                        puntos = 0;
                        total = 0; multiplicacionf = 0;
                        nombre = "";
                        nit = "";
                        correo = "";
                        CicloFacturacion = "S";
                    // Limpiamos pantalla y comenzamos a solicitar los datos de las facturas
                    DATOS:
                        Console.Clear();
                        Console.WriteLine("Facturación");
                        Console.Write("\nIngrese Nombre de la factura: ");
                        nombre = Console.ReadLine();
                        Console.Write("Ingrese número de NIT: ");
                        nit = Console.ReadLine();
                        Console.Write("Ingrese correo eléctronico: ");
                        correo = Console.ReadLine();

                        /*Se verifica que el usuario haya ingresado todos los datos de la factura, en el caso
                         de que haya omitido uno se vuelven a soliciar todos los datos, de lo contrario el 
                         programa continua de manera normal*/
                        if (nombre != "" && nit != "" && correo != "")
                        {
                            goto SEGUIR;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nERROR: Por favor ingrese todos los datos para la factura");
                            Console.ReadKey();
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto DATOS;
                        }

                        SEGUIR:
                        // Mostramos los productos a elegir
                        Console.WriteLine("\n--------------------------------------------------------");
                        Console.WriteLine("|     CÓDIGO     |      PRODUCTO      |     PRECIO     |");
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine("|      001       |  LIBRA DE AZÚCAR   |     Q10.80     |");
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine("|      002       |  LIBRA DE ARROZ    |     Q3.80      |");
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine("|      003       |  GALLETA GAMA      |     Q1.10      |");
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine("|      004       |  COCA COLA         |     Q17.00     |");
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine("|      005       |  LIBRA DE CAFÉ     |     Q50.00     |");
                        Console.WriteLine("--------------------------------------------------------");

                        /* La solicitud de los productos estan dentro de un ciclo Do-While ya que no tenemos la
                           cantidad de ocasiones exactas en las que se ingresará un articulo */
                        do
                        {
                            /*Al inicio del ciclo volvemos a resetear los contadores individules de cada articulo
                              esto con el fin de permitirle al usuario volver a agregar un mismo articulo la cantidad
                              de ocasiones que desee  */
                            C001 = 0; C002 = 0; C003 = 0; C004 = 0; C005 = 0;
                            string cantidad = "";
                            Console.Write("\nIngrese código del producto: ");

                            //Nuevamente el Console.ReadLine lo trabajamos directamente en el switch
                            switch (Console.ReadLine())
                            {
                                // El case "001" es la libra de azucar
                                case "001":
                                    Console.Write("Ingrese cantidad de productos: ");
                                    cantidad= Console.ReadLine();
                                    /* Luego de solicitar la cantidad de productos verificamos por medio de un
                                       int.TryParse que el valor ingresado sea un entero */
                                    bool verificar = int.TryParse(cantidad, out C001);

                                    //En el caso de que la variable verificar sea verdadera se hace lo siguiente
                                    if (verificar == true)
                                    {
                                        /*Este proceso se hace unicamente si la cantidad de productos ingresados es
                                          mayor o igual a 1*/
                                        if (C001 >= 1)
                                        {
                                            /*La variable total0001 almacena la cantidad general de productos vendidos
                                             de libras de azucar y es el que se muestra en el reporte de facturación*/
                                            total001 = total001 + C001;
                                            /*La variable CF001 almacena la cantidad local de productos vendidos
                                             de libras de azucar y es el que se muestra al final de la factura, esto
                                             con el fin de permitirle al usuario que ingrese nuevamente el articulo
                                             y que la cifra final en la factura sea la correcta y no la última ingresada
                                             por el usuario*/
                                            CF001 = CF001 + C001;
                                            /*La variable multiplicacion almacena el precio total por articulo segun la 
                                              cantidad de articulos ingresados de libras de azucar*/
                                            multiplicacion = C001*10.80;
                                            /*La variable total va almacenando cada multiplicación para poder mostrar
                                              un total de factura al final de este ciclo*/
                                            total=total + multiplicacion;
                                        }
                                    }

                                    //En el caso de que la variable verificar sea falsa se hace lo siguiente
                                    else if (verificar == false)
                                    {
                                        /*Haciendo uso de un goto nos trasladamos a una sección declarada como novalido
                                          la cual muestra un error en especifico*/
                                        goto novalido;
                                    }
                                    break;

                                /*El proceso anterior se repite exactamente de la misma manera para los case "002",
                                  "003","004" y "005" con la diferencia de que se utilizaron las variables especificas
                                  para cada uno de los productos y sus respectivas cantidades*/

                                case "002":
                                    Console.Write("Ingrese cantidad de productos: ");
                                    cantidad = Console.ReadLine();
                                    bool verificar2 = int.TryParse(cantidad, out C002);
                                    if (verificar2 == true)
                                    {
                                        if (C002 >= 1)
                                        {
                                            total002 = total002 + C002;
                                            CF002 = CF002+ C002;
                                            multiplicacion = C002 * 3.80;
                                            total = total + multiplicacion;
                                        }
                                    }
                                    else if (verificar2 == false)
                                    {
                                        goto novalido;
                                    }
                                    break;
                                case "003":
                                    Console.Write("Ingrese cantidad de productos: ");
                                    cantidad = Console.ReadLine();
                                    bool verificar3 = int.TryParse(cantidad, out C003);
                                    if (verificar3 == true)
                                    {
                                        if (C003 >= 1)
                                        {
                                            total003 = total003 + C003;
                                            CF003 = CF003 + C003;
                                            multiplicacion = C003 * 1.10;
                                            total = total + multiplicacion;
                                        }
                                    }
                                    else if (verificar3 == false)
                                    {
                                        goto novalido;
                                    }
                                    break;
                                case "004":
                                    Console.Write("Ingrese cantidad de productos: ");
                                    cantidad = Console.ReadLine();
                                    bool verificar4 = int.TryParse(cantidad, out C004);
                                    if (verificar4 == true)
                                    {
                                        if (C004 >= 1)
                                        {
                                            total004 = total004 + C004;
                                            CF004= CF004 + C004;
                                            multiplicacion = C004 * 17.00;
                                            total = total + multiplicacion;
                                        }
                                    }
                                    else if (verificar4 == false)
                                    {
                                        goto novalido;
                                    }
                                    break;
                                case "005":
                                    Console.Write("Ingrese cantidad de productos: ");
                                    cantidad = Console.ReadLine();
                                    bool verificar5 = int.TryParse(cantidad, out C005);
                                    if (verificar5 == true)
                                    {
                                        if (C005 >= 1)
                                        {
                                            total005= total005 + C005;
                                            CF005 = CF005 + C005;
                                            multiplicacion = C005 * 50.00;
                                            total = total + multiplicacion;
                                        }
                                    }
                                    else if (verificar5 == false)
                                    {
                                        goto novalido;
                                    }
                                    break;
                                /* El siguiente case se declaró unicamente  para poder contener la sección novalido*/
                                case "asjd0w8er?'90124.-@#2381hi":
                                /* Acá inicia la seccion novalido y muestra un error de que la cantidad de productos
                                   ingresados sin importar el articulo elejido no es válido, esto puede ser causado ya
                                   sea por que se ingresó una letra, un número decimal o cualquier valor diferente a un
                                   número entero*/
                                    novalido:
                                    /*Para cada ocasión de un error se hace lo siguiente: se establece un color de consola
                                      color rojo, se muestra el mensaje de error y por ultimo se reinicia el color de la
                                      consola a color negro. Por lo que hace que unicamente la linea del error aparezca de
                                      color rojo*/
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("ERROR: Cantidad de Productos No Válido");
                                    Console.ReadKey();
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                                /*El default lo que hace es que si el usuario ingresó un codigo de articulo el cual no 
                                 se encuentra entre la lista de opciones muestra el error de producto no encontrado*/
                                default:
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("ERROR: Producto no encontrado");
                                    Console.ReadKey();
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                            }

                            /*Dentro de este if se encuentra la pregunta si desea continuar ingresando mas productos, en
                             el caso de ingresar "s" el ciclo se vuelve a repetir mientras que si ingresa "n", se le da un
                             valor de "N", a la variable de CicloFacturacion para que así cuando llegue al final del ciclo
                             el while verifica que valor contiene la variable de CicloFacturacion para saber si debe repetir
                             el proceso de ingresar un articulo y su cantidad*/

                            if (total >= 1) //se utilizó la validación de total>=1 para evitar que una factura se vaya con valor cero
                            {
                                /*Se declaró la seccion de DESEACONTINUAR en el caso de que el usuario ingrese una opcion no válida*/
                                DESEACONTINUAR:
                                Console.Write("Desea con continuar (S/N): ");
                                string continuar = Console.ReadLine();
                                /*Para evitar estar verificando mayusculas o minusculas en los if siguientes se optó por convertir
                                  siempre a minusculas la opción almacenada en si desea continuar o no ingresando articulos*/
                                continuar.ToLower();

                                if (continuar == "n")
                                {
                                    CicloFacturacion = "N";
                                }
                                /*El siguiente if verifica si el usuario ingresó una opcion no valida ya sea S o N y lo que hace es
                                  al tener un goto adentro traslada al usuario nuevamente a la seccion de DESEACONTINUAR y vuelve a 
                                  realizar la pregunta si desea o no desea continuar ingresando articulos*/
                                else if (continuar != "s" && continuar != "s")
                                {
                                    goto DESEACONTINUAR;
                                }
                            }
                        } while (CicloFacturacion == "S"); /*El ciclo de ingreso de productos se repite siempre y cuando la variable 
                                                            CicloFacturacion sea igual a "S"*/
                        
                        /*En esta sección comienza la consulta al usuario del metodo de pago y se declaró la seccion
                          METODODEPAGO para poder volver a hacer la consulta en el caso de que se ingrese una opción
                          no válida*/
                        METODODEPAGO:
                        Console.Clear();
                        Console.WriteLine("Método de pago\n\n1. Tarjeta de crédito o débito\n2. Efectivo");
                        Console.Write("\nIngrese número de opción: ");
                        opcionpago=Console.ReadLine();

                        /*Para la generación de los puntos si el metodo de pago fue con tarjeta se utilizó un if para verificar*/
                        if (opcionpago == "1")
                        {
                            /*En el caso de que el monto estuviese entre Q10 y Q50 se generaban 1 punto por cada Q10*/
                            if(total>=10 && total<=50) 
                            {
                                puntos = Convert.ToInt32(total / 10);
                                /*Debido a que al hacer la división si el resultado decimal es por ejemplo 2.6 lo aproxima a
                                  al entero siguiente generando 3 puntos por una compra de Q26 lo cual es incorrecto por lo que
                                  el siguiente if lo que hace es confirmar si la cantidad de puntos x Q10 es mayor al monto total
                                  de la factura, entonces si el resultado es verdadero resta un punto obteniendo. Por ejemplo el 
                                  valor correcto para una compra de Q26 seria de 2 puntos*/
                                if ((puntos * 10) > total)
                                {
                                    puntos = puntos - 1;
                                }
                            }
                            /*Para los montos totales en un rango de Q50 y Q100 se asigna directamente la cantidad de 7 puntos ya
                              que se otorgaron 5 puntos por el primer rango y se añadieron los otros 2 puntos al momento de entrar
                              en este rango*/
                            else if (total >50 && total <= 100)
                            {
                                puntos = 7;
                            }
                            /*Para las compras mayores a Q100 se asignó directamente 10 puntos ya que al cumplir con los dos rangos
                             anteriores el usuario llevaria acumulados 7 puntos mas los 3 puntos al momento de sobrepasar el rango de
                             los Q100*/
                            else if (total > 100)
                            {
                                puntos = 10;
                            }

                            /*La variable puntostotales lleva el control de la cantidad de puntos totales generados para posteriormente
                              poder ser mostrado en el reporte general*/
                            puntostotales = puntostotales + puntos;
                        }

                        /*En el caso de que el usuario ingrese una opción no válida, se verifica y se vuelve a solicitar que ingrese
                          uno de los dos metodos de pago disponibles regresando a la seccion de METODODEPAGO a traves de un goto*/
                        else if (opcionpago != "1" && opcionpago != "2")
                        {

                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nERROR: Opción no válida");
                            Console.ReadKey();
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto METODODEPAGO;
                        }

                        /*En esta sección se limpia la pantalla y se muestra el detalle completo de la factura de compra*/
                        Console.Clear();
                        Console.WriteLine("\t\t\t\t\t\tFACTURA");
                        Console.WriteLine("\n\t\tTIENDA MAS - URL\t\t\t\tNIT: 1645848-5");
                        Console.WriteLine("\t\tFecha: " + fecha+ "\t\t\t\tNúmero de Factura: " + numerofactura);
                        Console.WriteLine("\t\tNIT: " + nit + "\t\t\t\t\tNombre del cliente: " + nombre);
                        Console.WriteLine("\t\tPuntos acumulados: " + puntos);
                        Console.WriteLine("\n   Producto            Cantidad             Precio Unitario             Precio Total Por Producto");

                        /*Los siguientes cinco IF se utilizaron para verificar que exista una cantidad del producto en especifico
                          para poder mostrar unicamente los articulos comprados y evitar dejar espacios en blanco o que aparezcan
                          articulos con cantidad de cero*/
                        if(CF001 >= 1)
                        {
                            /*Dentro de cada IF se encuentra la variable multiplicacionf la cual su funcion es unicamente mostrar
                              el precio total por producto de manera individual, es por ello que su valor cambia dentro de cada IF*/
                            multiplicacionf = CF001 * 10.80;
                            Console.WriteLine(" Libra de Azúcar\t  " + CF001 + "\t\t\tQ10.80\t\t\t\tQ" + multiplicacionf);
                        }
                        if (CF002 >= 1)
                        {
                            multiplicacionf = CF002 * 3.80;
                            Console.WriteLine(" Libra de Arroz \t  " + CF002 + "\t\t\tQ3.80\t\t\t\tQ" + multiplicacionf);
                        }
                        if (CF003 >= 1)
                        {
                            multiplicacionf = CF003 * 1.10;
                            Console.WriteLine(" Galleta GAMA   \t  " + CF003 + "\t\t\tQ1.80\t\t\t\tQ" + multiplicacionf);
                        }
                        if (CF004 >= 1)
                        {
                            multiplicacionf = CF004 * 17.00;
                            Console.WriteLine(" Coca Cola      \t  " + CF004 + "\t\t\tQ17.00\t\t\t\tQ" + multiplicacionf);
                        }
                        if (CF005 >= 1)
                        {
                            multiplicacionf = CF005 * 50.00;
                            Console.WriteLine(" Libra de café  \t  " + CF005 + "\t\t\tQ50.00\t\t\t\tQ" + multiplicacionf);
                        }
                        /*En esta parte se muestra el total de la factura mostrando la variable llamada total, la cual su valor
                          se fue actualizando y aumentando durante el ingreso de los productos*/
                        Console.WriteLine("\n\t\t\t\t             Total de la factura:\t\tQ" + total);
                        Console.ReadLine();
                        /*Como última parte de esta sección se le suma 1 a la variable numerofactura para que al momento de ingresar
                         una nueva compra, ya comience con el siguiente numero de factura*/
                        numerofactura += 1;
                        break;
                    // El case "2" es la opción de Reportes de facturación
                    case "2":

                        Console.Clear(); Console.Clear();
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("|     Reportes de Facturación     |");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("| 1. Total de facturas realizadas |");
                        Console.WriteLine("| 2. Total de productos vendidos  |");
                        Console.WriteLine("| 3. Total de puntos generados    |");
                        Console.WriteLine("-----------------------------------");
                        Console.Write("\n Ingrese número de opción: ");

                        // Para ingresar la opción se utilizó un switch que contiene directamente el Console.ReadLine();
                        switch (Console.ReadLine())
                        {

                            // El case "1" muestra el total de facturas realizadas
                            case "1":
                                /*Para ello dentro de este case se creó una tabla utilizando los simbolos "|" y "-".*/
                                Console.Clear(); 
                                Console.WriteLine("---------------------------------------------------------");
                                Console.WriteLine("|                 REPORTE DE FACTURACIÓN                |");
                                Console.WriteLine("---------------------------------------------------------");
                                /*Para mostrar la cantidad de facturas emitidas se manda a llamar a la variable numerofactura
                                  pero se le resta 1 debido a que cada vez que se emite una factura su valor aumenta al numero
                                  siguiente para el momento que se ingrese un nuevo dato, pero eso no significa que ese nuevo
                                  valor corresponda a una factura ya emitida, simplemente está a la espera de ser procesada*/
                                Console.WriteLine("| Total de Facturas Emitidas |\t\t" + Convert.ToString(numerofactura-1)+ "\t\t|");
                                Console.WriteLine("---------------------------------------------------------");
                                
                                break;

                            // El case "2" muestra el total de productos vendidos
                            case "2":
                                /*Al igual que en el reporte anterior se creó una tabla utilizando los simbolos "|" y "-". 
                                  Para mostrar la cantidad individual de productos vendidos se mostraron las variables 
                                  total00# segun correspondiera, estas variables fueron procesadas durante el ingreso de los
                                  productos en la facturación*/
                                Console.Clear();
                                Console.WriteLine("---------------------------------------------------------");
                                Console.WriteLine("|                REPORTE DE FACTURACIÓN                 |");
                                Console.WriteLine("---------------------------------------------------------");
                                Console.WriteLine("|          PRODUCTO        |       CANTIDAD VENDIDOS    |");
                                Console.WriteLine("---------------------------------------------------------");
                                Console.WriteLine("|      Libra de azúcar     |\t\t" + total001 + "\t\t|");
                                Console.WriteLine("---------------------------------------------------------");
                                Console.WriteLine("|      Libra de arroz      |\t\t" + total002 + "\t\t|");
                                Console.WriteLine("---------------------------------------------------------");
                                Console.WriteLine("|      Galleta Gama        |\t\t" + total003 + "\t\t|");
                                Console.WriteLine("---------------------------------------------------------");
                                Console.WriteLine("|      Coca Cola           |\t\t" + total004 + "\t\t|");
                                Console.WriteLine("---------------------------------------------------------");
                                Console.WriteLine("|      Libra de café       |\t\t" + total005 + "\t\t|");
                                Console.WriteLine("---------------------------------------------------------");
                                break;
                            // El case "3" muestra el total de puntos emitidos por compras utilizando el metodo de pago "tarjeta"
                            case "3":
                                /*Nuevamente se creó una tabla utilizando los simbolos "|" y "-". Para este caso unicamente
                                  se muestra la variable puntostotales cuyo valor se procesó durante la facturación de los
                                  productos*/
                                Console.Clear();
                                Console.WriteLine("---------------------------------------------------------");
                                Console.WriteLine("|                 REPORTE DE FACTURACIÓN                |");
                                Console.WriteLine("---------------------------------------------------------");
                                Console.WriteLine("|  Total de puntos emitidos  |\t\t" + puntostotales + "\t\t|");
                                Console.WriteLine("---------------------------------------------------------");
                                break;

                            /*El default lo que hace es que si el usuario ingresó un numero de opcion de reporte no valido,
                              se le muestra el error de opcion no válida*/
                            default:

                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\nERROR: Opción no válida");
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                        }
                        Console.ReadKey();
                        break;
                    // El case "3" es la opción de salir del programa
                    case "3":
                        /*En el caso de que el usuario haya ingresado la opción por error se le pregunta si está seguro que
                          desea salir del programa*/
                        Console.Clear();
                        Console.Write("Está seguro que desea salir (S/N): ");
                        string continuar2 = Console.ReadLine();
                        continuar2.ToLower();
                        /*En el caso de que el usuario confirme que desea salir, se le asigna un valor de "N" a la variable
                          CicloPrincipal para que al momento de que While al final del ciclo verifique que CicloPrincipal ya
                          no es igual a "S" automaticamente finalizará la ejecución del programa*/
                        if (continuar2 == "s")
                        {
                            CicloPrincipal = "N";
                        }
                        break;

                    /*El default lo que hace es que si el usuario ingresó un numero de opcion no válida se le muestra el error 
                     * de Usted ha ingresado una opcion no válida y se vuelve a repetir el ciclo*/
                    default:
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nERROR: Usted ha ingresado una opción no valida");
                        Console.ReadKey();
                        break;
                }
            //Este ciclo se repetira siempre y cuando el valor de CicloPrincipal sea igual a "S"
            } while (CicloPrincipal == "S");
        }
    }
}
