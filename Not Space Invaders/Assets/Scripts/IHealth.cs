public interface IHealth
{
    int health { get; set; }

    void TakeDamage(int damageAmount = 1);
}
