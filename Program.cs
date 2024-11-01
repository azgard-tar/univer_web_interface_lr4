using System;
using System.Reflection;

namespace LR4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Отримання типу класу через Type
            Type studentType = typeof(Student);
            Console.WriteLine("Тип класу Student: " + studentType);

            // 2. Робота з TypeInfo
            TypeInfo typeInfo = studentType.GetTypeInfo();
            Console.WriteLine("\nІнформація про тип (TypeInfo):");
            Console.WriteLine("Ім'я типу: " + typeInfo.Name);
            Console.WriteLine("Чи є класом: " + typeInfo.IsClass);
            Console.WriteLine("Чи має публічний конструктор: " + typeInfo.IsPublic);

            // 3. Робота з MemberInfo для отримання всіх членів класу
            Console.WriteLine("\nЧлени класу (MemberInfo):");
            MemberInfo[] members = studentType.GetMembers();
            foreach (var member in members)
            {
                Console.WriteLine($"{member.MemberType}: {member.Name}");
            }

            // 4. Робота з FieldInfo для отримання полів класу
            Console.WriteLine("\nПоля класу (FieldInfo):");
            FieldInfo[] fields = studentType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                Console.WriteLine($"Поле: {field.Name}, Тип: {field.FieldType}, Доступ: {field.Attributes}");
            }

            // 5. Робота з MethodInfo для отримання методів класу і виклик одного з них через Reflection
            Console.WriteLine("\nМетоди класу (MethodInfo):");
            MethodInfo[] methods = studentType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var method in methods)
            {
                Console.WriteLine($"Метод: {method.Name}, Повертає: {method.ReturnType}, Доступ: {method.Attributes}");
            }

            // Виклик методу Greet() через Reflection
            Console.WriteLine("\nВиклик методу Greet через Reflection:");
            var studentInstance = Activator.CreateInstance(studentType, "Taras Chepura", 91.1, 23, "401", true);
            MethodInfo greetMethod = studentType.GetMethod("Greet");
            greetMethod?.Invoke(studentInstance, null);

            // Виклик приватного методу GetAge() через Reflection
            Console.WriteLine("\nВиклик приватного методу GetAge через Reflection:");
            MethodInfo getAgeMethod = studentType.GetMethod("GetAge", BindingFlags.NonPublic | BindingFlags.Instance);
            int age = (int)getAgeMethod?.Invoke(studentInstance, null);
            Console.WriteLine("Вік: " + age);
        }
    }
}