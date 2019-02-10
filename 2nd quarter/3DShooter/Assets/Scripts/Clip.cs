namespace Game
{
    public class Clip
    {
        int _maxBulletsCount;
        int _currentBulletsCount;

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
