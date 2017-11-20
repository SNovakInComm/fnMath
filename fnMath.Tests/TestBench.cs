using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace fnMath.Tests
{
    public delegate void TestDelegate();

    public class TestBench
    {
        static void Main(string[] args)
        {
            Console.Write("\n\n\n");
            Console.Write("**************************************************\n");
            Console.Write("**************************************************\n");
            Console.Write("                  Tests Begining\n");
            Console.Write("**************************************************\n");
            Console.Write("**************************************************\n\n\n");

            if (args.Length > 0)
                Console.WriteLine("Loading: " + args[0] + "\n");
            else
            {
                Console.Write("No Assembly passed to Tester!");
                Console.Write("Usage: <libraryName>.Tester.exe <libraryName>.dll\n\n\n");
                return;
            }

            AssemblyName name = AssemblyName.GetAssemblyName(System.IO.Directory.GetCurrentDirectory() + "\\bin\\" + args[0]);
            Assembly testAssembly = Assembly.Load(name);

            List<Type> listOfTestFixtures = GetTestBenches(testAssembly);

            System.Console.WriteLine("Found " + listOfTestFixtures.Count + " test fixtures...\n\n");

            foreach (Type t in listOfTestFixtures)
            {
                System.Console.WriteLine("Type is: " +t.ToString());


                MethodInfo[] methods = t.GetMethods();

                Object testFixture = Activator.CreateInstance(t);

                foreach(MethodInfo info in methods.Where(n => n.GetCustomAttributes(typeof(Test), false).Length > 0))
                {
                    Object someObject = new object();
                    System.Console.WriteLine(info + "\n");
                    TestDelegate del = (TestDelegate) Delegate.CreateDelegate(typeof(TestDelegate), testFixture, info);
                    object result = del.
                }

            }

            return;
        }

        public static List<Type> GetTestBenches(Assembly assembly)
        {
            List<Type> types = new List<Type>();

            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(TestFixture), true).Length > 0)
                    types.Add(type);
            }

            return types;
        }

        public static List<Type> GetTests(Assembly assembly)
        {
            List<Type> types = new List<Type>();

            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(TestFixture), true).Length > 0)
                    types.Add(type);
            }

            return types;
        }
    }
}
