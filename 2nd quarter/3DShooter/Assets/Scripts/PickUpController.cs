

namespace Game
{
    class PickUpController:BaseController
    {
        public void PickUp(PickbleItemInfo info)
        {
            switch (info.Type)
            {
                case PickbleItemType.Ak:
                    break;
                case PickbleItemType.Glock:
                    break;
                case PickbleItemType.Famas:
                    break;
                case PickbleItemType.AkClip:
                    break;
                case PickbleItemType.GlockClip:
                    break;
                case PickbleItemType.FamasClip:
                    break;
                case PickbleItemType.Pass:
                    break;
                case PickbleItemType.MedKit:
                    break;
                case PickbleItemType.Granade:
                    break;
                default:
                    break;
            }
        }
    }
}
