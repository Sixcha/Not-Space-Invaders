public interface IHealth
{
    int Health { get; set; }

    void TakeDamage(int damageAmount = 1);
}
