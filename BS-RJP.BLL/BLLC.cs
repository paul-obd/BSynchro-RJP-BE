using BS_RJP.DAL;

namespace BS_RJP.BLL
{
    public partial class BLLC : IBLLC
    {
        private readonly IDALC _DALC;
        public BLLC(IDALC DALC)
        {
            _DALC = DALC;
            SubscribeToEvents();
        }
    }
}