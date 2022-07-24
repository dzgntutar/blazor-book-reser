using Blazored.Modal;
using Blazored.Modal.Services;
using BookReservation.Client.Components.Popups;

namespace BookReservation.Client.Utils
{
    public class ModalManager
    {
        private readonly IModalService modalService;

        public ModalManager(IModalService ModalService)
        {
            modalService = ModalService;
        }

        public async Task ShowMessageAsync(String Title, String Message, int Duration = 0)
        {
            ModalParameters mParams = new ModalParameters();
            mParams.Add("Message", Message);

            var modalRef = modalService.Show<ShowMessagePopupComponent>(Title, mParams);

            if (Duration > 0)
            {
                await Task.Delay(Duration);
                modalRef.Close();
            }
        }
    }
}
