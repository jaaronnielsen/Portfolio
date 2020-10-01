namespace Portfolio.shared.ViewModels
{
    public class LanguageViewModel
    {
        public LanguageViewModel() { }
        public LanguageViewModel(Language l)
        {
            Id = l.Id;
            Name = l.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}