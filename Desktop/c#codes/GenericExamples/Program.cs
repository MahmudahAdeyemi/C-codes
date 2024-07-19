// See https://aka.ms/new-console-template for more information
namespace GenericExamples
{
    public class Program
    {
        public static void Main(string [] args)
        {
            var atm = new ATMCounter<PaperNote>();
            var tenNairaNote = new PaperNote{ Value= 10D};
            atm.Notes.Add(tenNairaNote);
            var fiveNairaNote = new PaperNote{ Value= 5D};
            atm.Notes.Add(fiveNairaNote);
            var atm2 = new ATMCounter<Coin>();
            var tenkobo = new Coin{ Value= 10D};
            atm2.Notes.Add(tenkobo);
            var fivekobo = new Coin{ Value= 5D};
            atm2.Notes.Add(fivekobo);
            Console.WriteLine($"Total Notes {atm.AvailabeNotes()}");
            Console.WriteLine($"Total Amount {atm.TotalAmount()}");
        }
    }

}

