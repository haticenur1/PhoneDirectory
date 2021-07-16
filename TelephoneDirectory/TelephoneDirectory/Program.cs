using System;
using System.Collections.Generic;
using System.IO;

namespace TelephoneDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu;
            do
            { 
                Console.WriteLine("\n--------------");
                Console.WriteLine("| 1-Ekle     |");
                Console.WriteLine("| 2-Sil      |");
                Console.WriteLine("| 3-Güncelle |");
                Console.WriteLine("| 4-Listele  |");
                Console.WriteLine("| 5-Ara      |");
                Console.WriteLine("| 6-Çıkış    |");
                Console.WriteLine("--------------");
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine("Yapmak istediğiniz işlemi seçiniz.");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        DeleteContact();
                        break;
                    case 3:
                        UpdateContact();
                        break;
                    case 4:
                        ListContacts();
                        break;
                    case 5:
                        SearchContact();
                        break;
                    case 6:
                        Console.WriteLine("Çıkış yaptınız.");
                        break;
                    default:
                        Console.WriteLine("Lütfen menüden bir numara seçiniz!");
                        break;
                }
            }
            while (menu != 6);
        }
        public static string RehberBilgileri()
        {
            Console.WriteLine("\nAdı: ");
            string name = Console.ReadLine();
            Console.WriteLine("Soyadı: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Telefon Numarası: ");
            string phone = Console.ReadLine();
            string RehberBilgisi = name + " " + surname + " -- " + phone;
            return RehberBilgisi;
        }
        public static string FilePath()
        {
            string filePath = @"C:\Users\cozum\Desktop\TelefonRehberi.txt";
            return filePath;
        }
        public static void AddContact() 
        {
            StreamWriter writer = File.AppendText(FilePath());
            string bilgi =  RehberBilgileri();
            writer.WriteLine(bilgi);
            Console.WriteLine("\nEkleme İşleminiz Başarıyla Gerçekleştirilmiştir.");
            writer.Flush();
            writer.Close();
        }
        public static void DeleteContact() 
        {
            var file = new List<string>(File.ReadAllLines(FilePath()));
            Console.WriteLine("Silmek istediğiniz kişinin sıra numarsını yazınız.");
            int number = int.Parse(Console.ReadLine());
            file.RemoveAt(number);
            File.WriteAllLines(FilePath(), file.ToArray());
            Console.WriteLine("Silme işleminiz gerçekleşmiştir.");
        }
        public static void UpdateContact() 
        {
            List<string> persons = new List<string>(File.ReadAllLines(FilePath()));
            Console.WriteLine("Güncellemek istediğiniz kişinin sıra numarsını yazınız.");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Güncel bilgileri ad soyad -- telefon numarası şeklinde giriniz.");
            string newInformation = Console.ReadLine();
            persons[number] = newInformation;
            File.WriteAllLines(FilePath(), persons.ToArray());
            Console.WriteLine("Güncelleme işleminiz gerçekleşmiştir.");
        }
        public static void ListContacts() 
        {
            string [] list = File.ReadAllLines(FilePath());
            Array.Sort(list);
            List<string> persons = new List<string>(list);
            for (int i = 0; i < persons.Count; i++)
            {
                Console.WriteLine("\n" + i + " " + persons[i]);
            }
            File.WriteAllLines(FilePath(), list);
        }
        public static void SearchContact() 
        {
            StreamReader reader = new StreamReader(FilePath());
            Console.WriteLine("Aramak istediğiniz kişiyi giriniz.");
            string serachedWord = Console.ReadLine();
            string read = reader.ReadToEnd();
            int index = read.IndexOf(serachedWord);
            if (index == -1)
            {
                Console.WriteLine("Kişi bulunamadı.");
            }
            else
                Console.WriteLine("\n" + read.Substring(index));
        }
       
    }
}
