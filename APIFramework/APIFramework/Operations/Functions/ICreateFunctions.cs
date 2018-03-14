namespace APIFramework.Operations.Functions
{
    public interface ICreateFunctions
    {
        IFunction<TParameters> Create<TParameters>(TParameters parameters = default(TParameters))
            where TParameters : IFunctionParameters;
    }
}