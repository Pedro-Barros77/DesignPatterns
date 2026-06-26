namespace ChainOfResponsibility.Solution.Handlers
{
    public abstract class BaseHandler<TRequest, TResponse> : IHandler<TRequest, Task<TResponse>>
    {
        private IHandler<TRequest, Task<TResponse>>? NextHandler { get; set; }

        public virtual async Task<TResponse> Handle(TRequest request)
        {
            if (NextHandler != null)
                return await NextHandler.Handle(request);

            throw new NotImplementedException("Fim da corrente de handlers. É necessário um handler final que sobrescreva totalmente o comportamento do pai.");
        }

        public IHandler<TRequest, Task<TResponse>> SetNext(IHandler<TRequest, Task<TResponse>> handler)
        {
            NextHandler = handler;
            return handler;
        }
    }
}
