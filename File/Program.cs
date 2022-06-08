//Retorna uma Lista com as posições de cada palavra encontrada:
List<int> LinePositions(string text, string search){
    List<int> a = new List<int>();
    int aux = 0;
    int i = 0;
    if (text.Length >= search.Length && text.Contains(search)){
        while (text.Contains(search)){
            for (i = text.IndexOf(search); i < text.IndexOf(search) + search.Length; i++){
                a.Add(i + aux);
            }
            aux = i + aux;
            i = 0;
            text = text.Substring(i + search.Length);
        }
    }
    return a;
}

//Abre os ficheiro em modo binário e diz o tamanho do ficheiro:
void Binary(string FilePath){
    int size = 0;
    FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
    BinaryReader br = new BinaryReader(fs);
    br.BaseStream.Position = 0x0; //Put the cursor at the beginning of the file         
    byte[] data = br.ReadBytes(0xA); // Read 10 bytes into an array    
    string data_as_hex = BitConverter.ToString(data);

    while (br.ReadBytes(1).Length > 0){
        size++;
    }

    br.Close();
    string a = Convert.ToString(size + 10);
    string aux = "";
    for (int i = 0; i < a.Length; i++){
        if (i % 3 == 0 && i != 0){
            aux = aux + " ";
        }
        aux = aux + a[a.Length - 1 - i];
    }
    Console.Write(aux.Reverse().ToArray());

    Console.Write(" bytes\n");
}

//Open the file and print the result:
void Search(string FilePath, string Word)
{
    FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(fs);

    int WordNumber = 0; //Counter of the number word wanted in the string
    int LineNumber = 1; //Counter of the number line in the file
    string ImportantLine = ""; //String que contem todas as linhas com a palavra procurada
    while (sr.EndOfStream == false){
        string line = sr.ReadLine();
        if (line.ToUpper().Contains(Word.ToUpper())){
            List<int> WordPositions = LinePositions(line.ToUpper(), Word.ToUpper());
            Console.ForegroundColor = ConsoleColor.Blue;
            if (LineNumber < 10){
                Console.Write(LineNumber + "  -> ");
            }   else{
                Console.Write(LineNumber + " -> ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < line.Length; i++){
                if (WordPositions.Contains(i)){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(line[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }   else{
                    Console.Write(line[i]);
                }
            }
            Console.WriteLine();
            WordNumber = WordNumber + WordPositions.Count/Word.Length; //Todos os caracteres que fazerem parte da palavra e divido pelo tamanho da palavra
            ImportantLine = ImportantLine + LineNumber + " -> " + line + "\n";
        }
        LineNumber++;
    }
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("\nWords number -> " + WordNumber);
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("\nFile size -> ");
    Binary(FilePath);
    Console.ForegroundColor = ConsoleColor.White;
    sr.Close();

    //Se o utilizador quiser copiar o output para um ficheiro:
    string copy = Console.ReadLine();
    if (copy.Split(' ')[0].ToUpper() == "COPY")
    {
        StreamWriter sw = new StreamWriter(copy.Split(' ')[1]);
        sw.Write(ImportantLine);
        sw.Close();
    }
}

Console.Clear();
Console.Write("Enter the file path -> ");
string FilePath = Console.ReadLine();

if (File.Exists(FilePath)){
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("File found!");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Enter the word to search -> ");
    string Word = Console.ReadLine();
    if (Word != null && Word.Length > 0){
        Search(FilePath, Word);
    }   else{
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Word is empty X-X");
        Console.ForegroundColor = ConsoleColor.White;
    }
}   else{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("File not found X-X");
    Console.ForegroundColor = ConsoleColor.White;
}