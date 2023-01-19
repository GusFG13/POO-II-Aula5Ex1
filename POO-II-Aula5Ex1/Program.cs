using System.Reflection;
using System.Xml.Linq;

namespace POO_II_Aula5Ex1
{

    /*
        Crie uma aplicação Console que contenha uma cópia da classe abaixo.

        public class Student
        {
            public string Name { get; set; }
            public string University { get; set; }
            public int RollNumber { get; set; }

            public void DisplayInfo()
            {
                Console.WriteLine($"{Name} - {University} - {RollNumber}");
            }
        }

        1. Em seguida, na classe Program, crie um método chamado DisplayPublicProperties que, usando 
           Reflection, exiba todas as Propriedades Públicas da classe Student. No método Main da classe 
           Program, coloque uma chamada para o método DisplayPublicProperties.

        2. Agora, adicione na classe Program um outro método chamado CreateInstance que
            1. Use Reflection para criar uma instância (objeto) da classe Student e, em seguida;
            2. Use Reflection para preencher as propriedades públicas do objeto. Não é necessário se 
               preocupar com a adição de novas propriedades, isto é, sempre serão preenchidos apenas o 
               Name, University e RollNumber.
            3. Use Reflection para chamar o método DisplayInfo do objeto criado no item 2.1.

        3. Ao final do exercício, coloque o seu cródigo em um repositório público no GitHub e submeta o link 
           para avaliação.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            DisplayPublicProperties(student);

            Console.WriteLine();
            Object newStudent = CreateInstance();
            DisplayPublicProperties(newStudent);
            FillPublicProperties(newStudent, "João Silva", "USP", 123456);

            Console.WriteLine();
            
            newStudent.GetType().GetMethod("DisplayInfo").Invoke(newStudent, new object[] {});
            //DisplayInfo(newStudent);

        }

        public static void DisplayPublicProperties(Object obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
            Console.WriteLine($"Propriedades públicas da classe {obj.GetType()}: ");
            foreach (var propertyInfo in propertyInfos)
            {
                Console.WriteLine($"  - {propertyInfo.Name} (tipo {propertyInfo.PropertyType.Name}).");
            }
        }

        public static Object CreateInstance()
        {
            return Activator.CreateInstance<Student>(); ;
        }

        public static void FillPublicProperties(Object obj, string name, string university, int rollNumber)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                switch (propertyInfo.Name)
                {
                    case "Name":
                        propertyInfo.SetValue(obj, name);
                        break;
                    case "University":
                        propertyInfo.SetValue(obj, university);
                        break;
                    case "RollNumber":
                        propertyInfo.SetValue(obj, rollNumber);
                        break;
                    default:
                        break;
                }
            }
        }

        //public static void DisplayInfo(Object obj)
        //{
        //    PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
        //    Console.WriteLine($"Tipo do objeto criado {obj.GetType().Name}");

        //    foreach (var propertyInfo in propertyInfos)
        //    {
        //        Console.WriteLine($"{propertyInfo.Name}: {propertyInfo.GetValue(obj)}");
        //    }
        //}


    }
}