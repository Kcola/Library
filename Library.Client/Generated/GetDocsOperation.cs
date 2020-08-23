using System;
using System.Collections.Generic;
using StrawberryShake;

namespace Library.Client.Generated
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetDocsOperation
        : IOperation<IGetDocs>
    {
        public string Name => "getDocs";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Query;

        public Type ResultType => typeof(IGetDocs);

        public Optional<string> Search { get; set; }

        public Optional<string> After { get; set; }

        public Optional<string> Before { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (Search.HasValue)
            {
                variables.Add(new VariableValue("search", "String", Search.Value));
            }

            if (After.HasValue)
            {
                variables.Add(new VariableValue("after", "String", After.Value));
            }

            if (Before.HasValue)
            {
                variables.Add(new VariableValue("before", "String", Before.Value));
            }

            return variables;
        }
    }
}
