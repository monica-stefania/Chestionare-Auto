namespace Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public List<int> CorrectOptionsIndex { get; set; }
        public string Image { get; set; }
        public string Category { get; set; } = string.Empty;
        public Question(int id, string text, List<string> options, List<int> correctOptionsIndex, string image, string category)
        {
            Id = id;
            Text = text;
            Options = options;
            CorrectOptionsIndex = correctOptionsIndex;
            Image = image;
            Category = category;
        }
    }
}