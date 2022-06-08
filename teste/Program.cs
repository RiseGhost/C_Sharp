
void teste(){
    int a = 0;
    for (int i = 0; i < 100000000; i++){
        a++;
    }
    for (int i = 0; i < 10; i++){
        teste();
    }
    Console.WriteLine(a);
}

Console.WriteLine("Hello");
var d = DateTime.Now;
Console.WriteLine(d);
Console.WriteLine(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
Console.WriteLine("World");
Console.ReadLine();