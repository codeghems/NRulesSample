
using NRules.Fluent.Dsl;

namespace NRulesSample
{
    public class AbcRule : Rule
    {
        public override void Define()
        {
            Guid AbcId = default!;
            IEnumerable<Abc> abcCollection = default!;

            When()
                .Match(() => AbcId)
                .Query(() => abcCollection, k => k
                    .Match<Abc>(a => a.AbcId == AbcId)
                    .Collect());

            Then()
                .Do(ctx => ctx.Insert(ProcessResult(AbcId, abcCollection)));
        }

        private AbcResult ProcessResult(Guid abcId, IEnumerable<Abc> abcCollection)
        {
            var count = abcCollection.Count();
            return new AbcResult();
        }
    }
}
