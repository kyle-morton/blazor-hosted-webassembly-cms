namespace BlazorCMS.SharedModels.ViewModels
{
    public class SelectListItem
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public static SelectListItem From(int value, string text)
        {
            return new SelectListItem
            {
                Value = value,
                Text = text
            };
        }
    }
}
