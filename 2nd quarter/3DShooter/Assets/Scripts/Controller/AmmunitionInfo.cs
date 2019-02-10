namespace Game
{
    struct AmmunitionInfo
    {
        public int CurrentBulletsCount;
        public int MaxBulletCount;
        public int CurrentClipCount;
        public int MaxClipCount;

        public override string ToString()
        {
            return $"CurrentBulletsCount:{CurrentBulletsCount}" +
                   $" MaxBulletCount:{MaxBulletCount}" +
                   $" CurrentClipCount:{CurrentClipCount}" +
                   $" {MaxClipCount}";
        }
    }
}
