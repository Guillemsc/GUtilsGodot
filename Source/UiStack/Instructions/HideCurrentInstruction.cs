using System.Threading;
using System.Threading.Tasks;
using GUtils.Repositories;
using GUtils.Tasks.Sequencing.Instructions;
using GUtilsGodot.UiStack.UseCases;

namespace GUtilsGodot.UiStack.Instructions
{
    public sealed class HideCurrentInstruction : Instruction
    {
        readonly ISingleRepository<object> _currentContextRepository;
        readonly bool _pushToViewQueue;
        readonly bool _instantly;
        readonly HideUseCase _hideUseCase;

        public HideCurrentInstruction(
            ISingleRepository<object> currentContextRepository,
            bool pushToViewQueue,
            bool instantly,
            HideUseCase hideUseCase
        )
        {
            _currentContextRepository = currentContextRepository;
            _pushToViewQueue = pushToViewQueue;
            _instantly = instantly;
            _hideUseCase = hideUseCase;
        }

        protected override Task OnExecute(CancellationToken cancellationToken)
        {
            bool entryFound = _currentContextRepository.TryGet(
                out object viewContext
            );

            if(!entryFound)
            {
                return Task.CompletedTask;
            }

            return _hideUseCase.Execute(viewContext, _pushToViewQueue, _instantly, cancellationToken);
        }
    }
}
