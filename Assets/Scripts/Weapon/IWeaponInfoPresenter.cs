namespace Weapon
{
    public interface IWeaponInfoPresenter
    {
        public string DamagePerShot { get; }
        public float ReloadSpeed { get; }
        public int MagazineMaxCapacity { get; }
    }
}
