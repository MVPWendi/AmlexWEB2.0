namespace AmlexWEB.Models.Rules
{
    public class RulesModel
    {
        public IEnumerable<RuleSection> RuleSections { get; set; }


        public RulesModel()
        {
            var sect = new List<RuleSection>();

            sect.Add(new RuleSection
            {
                Name = "Загловок 1",
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Text = "Нельзя"
                    },
                    new Rule
                    {
                        Text = "Нельзя2"
                    }
                }
            });

            sect.Add(new RuleSection
            {
                Name = "Загловок 2",
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        Text = "Нельзя"
                    },
                    new Rule
                    {
                        Text = "Нельзя2"
                    }
                }
            });

            RuleSections = sect;
        }
    }
}
