using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GUtils.Repositories;
using GUtils.Tasks.Sequencing.Instructions;
using GUtilsGodot.UiStack.UseCases;

namespace GUtilsGodot.UiStack.Instructions
{
    public sealed class HideAllPopupsInstruction : Instruction
    {
        readonly IListRepository<object> _currentPopupsRepository;
        readonly bool _instantly;
        readonly HideUseCase _hideUseCase;

        public HideAllPopupsInstruction(
            IListRepository<object> currentPopupsRepository,
            bool instantly,
            HideUseCase hideUseCase
            )
        {
            _currentPopupsRepository = currentPopupsRepository;
            _instantly = instantly;
            _hideUseCase = hideUseCase;
        }

        protected override Task OnExecute(CancellationToken cancellationToken)
        {
            List<Task> tasks = new();

            for (int i = _currentPopupsRepository.Count - 1; i >= 0; --i)
            {
                object instance = _currentPopupsRepository.Items[i];

                tasks.Add(_hideUseCase.Execute(instance, false, _instantly, cancellationToken));
            }

            return Task.WhenAll(tasks);
        }
    }
}
