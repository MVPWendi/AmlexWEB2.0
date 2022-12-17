namespace AmlexWEB.Models.Rules
{
    public class RuleSection
    {
        public string Name { get; set; }
        public IEnumerable<Rule> Rules { get; set; }
    }
}