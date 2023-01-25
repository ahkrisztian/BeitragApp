using Microsoft.AspNetCore.Components;

namespace BeitragRdrBlazorServerApp.Data
{
    public class Timer : ComponentBase
    {

        [Parameter]
        public double TimeInSeconds { get; set; }

        [Parameter]
        public Action Tick { get; set; } = default!;

        protected override void OnInitialized()
        {
            var time = new System.Threading.Timer(
                callback: (_) => InvokeAsync(() => Tick?.Invoke()),
                state: null,
                dueTime: TimeSpan.FromSeconds(TimeInSeconds),
                period: Timeout.InfiniteTimeSpan);
        }
    }
}
