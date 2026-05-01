public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public List<string> Options { get; set; }
    public int CorrectOptionIndex { get; set; }
    public string Image { get; set; }
    public string Category { get; set; } = string.Empty;
    public Question(int id, string text, List<string> options, int correctOptionIndex, string image, string category)
    {
        Id = id;
        Text = text;
        Options = options;
        CorrectOptionIndex = correctOptionIndex;
        Image = image;
        Category = category;
    }

    public bool IsCorrect(int selectedOptionIndex)
    {
        if(selectedOptionIndex < 0 || selectedOptionIndex >= Options.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(selectedOptionIndex), "Selected option index is out of range.");
        }

        return selectedOptionIndex == CorrectOptionIndex;
    }
}