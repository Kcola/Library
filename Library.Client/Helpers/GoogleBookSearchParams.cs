using System.Collections.Generic;

namespace Library.Client.Helpers
{
    public class GoogleBookSearchParams
    {
        public List<SearchParam> Params { get; set; }
        public override string ToString()
        {
            var _string = $"?key={Program.GoogleApiKey}&q=";
            foreach (SearchParam param in Params)
            {
                _string = $"{_string}{param.Field}:{param.Value}&";
            }
            return _string.Remove(_string.Length - 1, 1);
        }
    }
    public class SearchParam
    {
        public string Field { get; set; }
        public string Value { get; set; }
    }
}