namespace GenericExamples{
public class ATMCounter<T> where T : Currency{

    public List<T> Notes {get;set;} = new();

    public int AvailabeNotes(){
        return Notes.Count;
    }
    public double TotalAmount(){
        var sum = 0D;
        foreach(var note in Notes){
            sum += note.Value;
        }
        return sum;
    }       
}
}