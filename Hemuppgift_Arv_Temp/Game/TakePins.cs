namespace Hemuppgift_Arv_Temp.Game
{
    /*Svar på frågorna:
    F2.a) Basklass/superklass
    F2.b) 2, 3*/
    internal class TakePins
    {
        //Här är main klassen där koden ska testas, lägg in i mappen
        static void Main(string[] args)
        {
            Board board1 = new Board();
            board1.SetUp(10);

            board1.ShowGameBoard();

            board1.TakePins(2);

            Console.WriteLine(board1.GetNoPins());
            
        }

    }
}
