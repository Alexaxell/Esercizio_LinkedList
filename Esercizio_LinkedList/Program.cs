namespace Esercizio_LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();

            var head = new LinkedList<int>() { Value = 0 };
            var current = head;

            for (int i = 0; i < 20; i++)
            {
                current.Next = new LinkedList<int> { Value = r.Next(100) };
                current = current.Next;
            }

            current = head;
            int indice = 0;

            while (current != null)
            {
                if (current.Next == null)
                {
                    Console.WriteLine($"{current.Value}[{indice}]");
                    break;
                }
                Console.Write($"{current.Value}[{indice}] -> ");
                current = current.Next;
                indice++;
            }

            Console.WriteLine();

            Console.WriteLine("Inserisci la posizione di dove vuoi inserire l'elemento: ");
            int posizione = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci il valore:");
            int valore = int.Parse(Console.ReadLine());

            var nuovoNodo = new LinkedList<int> { Value = valore };

            if (posizione == 0)
            {
                nuovoNodo.Next = head;
                head = nuovoNodo;
            }
            else
            {
                current = head;
                int index = 0;

                while (current != null && index < posizione - 1)
                {
                    current = current.Next;
                    index++;
                }

                if (current == null)    
                    throw new ArgumentException("Posizione non valida.");

                else
                {
                    nuovoNodo.Next = current.Next;
                    current.Next = nuovoNodo;
                }

                Console.WriteLine("Lista aggiornata:");
                current = head;
                while (current != null)
                {
                    if (current.Next == null)
                    {
                        Console.WriteLine($"{current.Value}[{indice}]");
                        break;
                    }
                    Console.Write($"{current.Value}[{indice}] -> ");
                    current = current.Next;
                    indice++;
                }

                Console.WriteLine();

                current = head;
                while (current != null)
                {
                    if (current.Value % 2 == 0)
                        Console.WriteLine($"- {current.Value}[{indice}] -> PARI");
                    else
                        Console.WriteLine($"- {current.Value}[{indice}] -> DISPARI");
                    current = current.Next;
                    indice++;
                }
            }
        }
    }

    class LinkedList<T>
    {
        public T Value { get; set; }
        public LinkedList<T> Next { get; set; }
    }
}