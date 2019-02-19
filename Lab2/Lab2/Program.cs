using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Net.Mail;
using System.Net;
namespace Lab2
{
    public interface uni
    {
        void dodajStudent();
        void usunStudenta();
        void wyswetl_student();
        void srednia_wszystkich();

        void srednia_studenta();
        void wyswietl();


    }



    class Program : uni


    {

        double[] Listawszystkichocen = { 2, 2.5, 3, 3.5, 4, 4.5, 5 };

        List<Student> glowna = new List<Student>();
        public void dodajStudent()
        {
            Console.WriteLine("Nr indeksu ");
            int indeks = int.Parse(Console.ReadLine());
            Console.WriteLine("Imie");
            String imie = Console.ReadLine();
            Console.WriteLine("Nazwisko ");
            String nazwisko = Console.ReadLine();
            Console.WriteLine("Rok ");
            int rok = int.Parse(Console.ReadLine());
            Console.WriteLine("Oceny ");
            String oceny = Console.ReadLine();
            

            glowna.Add(new Student(indeks, imie, nazwisko, rok, oceny));


        }
        private void sendemail()
        {
            MailMessage wiadomosc = new MailMessage();
            wiadomosc.From = new MailAddress("rekrut_123@wp.pl");
            wiadomosc.Subject = "Witaj na platformie :)";
            wiadomosc.Body = "Witaj  na platformie MAIL :)  ";
            wiadomosc.To.Add("rekrut_123@wp.pl");

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("rekrut_123", "TEST123$");
            client.Host = "smtp.wp.pl";
            client.Port = 587;
            client.EnableSsl = true;
            client.Send(wiadomosc);


        }

        public void zapis_do_pliku()
        {
            try
            {
                StreamWriter file = new System.IO.StreamWriter("C:\\Users\\Krystian\\Desktop\\Studenci.txt");

                foreach (Student O in glowna)
                {
                    file.WriteLine("\n" + "Nr_indeksu " + O.Nr_indeksu);
                    file.WriteLine("\n" + "Imie " + O.Imie);
                    file.WriteLine("\n" + "Nazwisko " + O.Nazwisko);
                    file.WriteLine("\n" + "Rok_st " + O.Rok_st);
                    file.WriteLine("\n" + "Oceny  " + O.Oceny);
                }
                file.Close();
            }
            catch (Exception e)
            {

            }
        }
        public void usunStudenta()
        {

            Console.WriteLine("Jaki numer indeksu ?");
            int rem = int.Parse(Console.ReadLine());

            glowna.RemoveAll(a => a.Nr_indeksu.Equals(rem));





        }
        public void wyswetl_student()
        {
            foreach (Student K in glowna)
            {

                Console.WriteLine("Id osoby: " + K.Nr_indeksu +
       "\nImię: " + K.Imie +
       "\nNazwisko: " + K.Nazwisko +
       "\nRok_St: " + K.Rok_st +
       "\n Oceny: " + K.Oceny);

            }
        }
        public void srednia_studenta()
        {
            Console.WriteLine("Podaj numer indeksu studenta do obliczenia jego średniej ");
            int wybierz = int.Parse(Console.ReadLine());

            Student find = glowna.Find(a => a.Nr_indeksu.Equals(wybierz));
            String srednia = find.Oceny;
            char spliterator = ',';

            String[] tab = srednia.Split(spliterator);
            double konwersja;
            List<double> gl = new List<double>();
            foreach (String ks in tab)
            {

                konwersja = Convert.ToDouble(ks);
                if (konwersja <= 5)
                {
                    gl.Add(konwersja);
                }
                else
                {
                    Console.WriteLine("Użytkownik wprowadził złe dane ");
                }

            }
            Console.WriteLine(" Średnia wynosi  " + Math.Round(gl.Sum() / gl.Count(), 2));




        }
        public void srednia_wszystkich()
        {
            double konwersja;
            List<double> obblocz = new List<double>();
            foreach (Student flag in glowna)
            {
               
                String sredniaa = flag.Oceny;
                char spliteratory = ',';
                String[] sredniaki = sredniaa.Split(spliteratory);
                foreach (String ejbi in sredniaki)
                {
                    konwersja = Convert.ToDouble(ejbi);
                    obblocz.Add(konwersja);
                    Console.WriteLine(konwersja);
                }


            }
            Console.WriteLine("Średnia wszystkich studentów wynosi " + Math.Round(obblocz.Sum() / obblocz.Count, 2));


        }
        public void wyswietl()
        {
            Console.WriteLine("Wybierz");
            Console.WriteLine("1: Dodać studenta");
            Console.WriteLine("2: Usuń studenta");
            Console.WriteLine("3: Wyświetl studentów");
            Console.WriteLine("4: Oblicz średnią studenta");
            Console.WriteLine("5: Oblicz średnia wszystkich studentów");
            Console.WriteLine("6: Zapisz do pliku ");

            int a = int.Parse(Console.ReadLine());
            if (a == 1)
            {

                //dodajStudent();
                //wyswietl();
                while (true)
                {
                    sendemail();
                }
                


            }
            else if (a == 2)
            {
                usunStudenta();
                wyswietl();


            }
            else if (a == 3)
            {
                wyswetl_student();
                wyswietl();
            }
            else if (a == 4)
            {
                srednia_studenta();
                wyswietl();
            }
            else if (a == 5)
            {
                srednia_wszystkich();
                wyswietl();

            }
            else if (a == 6)
            {

                zapis_do_pliku();
                wyswietl();

            }
        }
        static void Main(string[] args)
        {
           
            Program oel = new Program();

            oel.wyswietl();

            Console.ReadLine();



        }
    }
    public class Student
    {
        private int nr_indeksu;
        private String imie;
        private String nazwisko;
        private int rok_st;
        private String oceny;




        public Student(int nr_indeksu, String imie, String nazwisko, int rok_st, String oceny)
        {

            this.nr_indeksu = nr_indeksu;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.rok_st = rok_st;
            this.oceny = oceny;
        }

        public void wyswietl()
        {
            Console.WriteLine(nr_indeksu);
            Console.WriteLine(imie);
            Console.WriteLine(nazwisko);
            Console.WriteLine(rok_st);

        }


        public int Nr_indeksu
        {
            get
            {
                return nr_indeksu;
            }

            set
            {
                nr_indeksu = value;
            }
        }

        public string Imie
        {
            get
            {
                return imie;
            }

            set
            {
                imie = value;
            }
        }

        public string Nazwisko
        {
            get
            {
                return nazwisko;
            }

            set
            {
                nazwisko = value;
            }
        }

        public int Rok_st
        {
            get
            {
                return rok_st;
            }

            set
            {
                rok_st = value;
            }
        }

        public string Oceny
        {
            get
            {
                return oceny;
            }

            set
            {
                oceny = value;
            }
        }
    }
}




