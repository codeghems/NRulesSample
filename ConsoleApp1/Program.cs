
using NRules;
using NRules.Fluent;
using NRulesSample;



var repository = new RuleRepository();
repository.Load(x => x.From(typeof(AbcRule).Assembly));

var factory = repository.Compile();
var session = factory.CreateSession();

var id = new Guid("450912D8-DB17-494B-B229-B6F12B5D51A2");

IEnumerable<Abc> abcCollection =
[
    new Abc{AbcId = new Guid("FEE363FB-B33F-478B-A556-DD089475CD83"), Name = "Hello1"},
    new Abc{AbcId = new Guid("FEE363FB-B33F-478B-A556-DD089475CD83"), Name = "Hello2"},
    new Abc{AbcId = new Guid("450912D8-DB17-494B-B229-B6F12B5D51A2"), Name = "Hello3"}
];

session.Insert(id);
session.InsertAll(abcCollection);

session.Fire();