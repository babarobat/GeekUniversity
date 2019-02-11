namespace Game
{
    public class Clip
    {
        int _maxBulletsCount;
        int _currentBulletsCount;
        public int CurrentBulletsCount
        {
            get => _currentBulletsCount;
            set => _currentBulletsCount = value < 0 ? 0 : value > _maxBulletsCount ? _maxBulletsCount : value;
        }

        public Clip (int maxBulletsCount)
        {
            _maxBulletsCount = maxBulletsCount;
            ReloadClip();
        }

        public void ReloadClip()
        {
            _currentBulletsCount = _maxBulletsCount;
        }

        
    }
}
