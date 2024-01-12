using System;

class Player
{
    private static int MAX_HEALTH = 1000;
    private static int MAX_ARMOR = 2000;
    private static int MAX_ATTACK = 100;

    public string ID = "";
    private int health = 0;
    private int armor = 0;
    private int attack = 0;

    public static void ResetHealthCap(int newMaxHealth)
    {
        MAX_HEALTH = newMaxHealth;
    }

    public void InitializePlayer(string ID, int health, int armor, int attack)
    {
        this.ID = ID;
        if (health > MAX_HEALTH)
            this.health = MAX_HEALTH;
        else
            this.health = health;

        if (armor > MAX_ARMOR)
            this.armor = MAX_ARMOR;
        else
            this.armor = armor;

        if (attack > MAX_ATTACK)
            this.attack = MAX_ATTACK;
        else
            this.attack = attack;
    }

    public void SetHealth(int health)
    {
        if (health > MAX_HEALTH)
            this.health = MAX_HEALTH;
        else
            this.health = health;
    }

    public int GetHealth()
    {
        return health;
    }
    public void TakeTurn(Player target)
    {
        Console.WriteLine($"{this.ID}'s turn. Press space to attack!");
        Console.ReadKey(true);
        ExecuteAttack(target);

        if (target.isDead())
        {
            Console.WriteLine($"{target.ID} is dead. {this.ID} wins!");
            Environment.Exit(0);
        }

        Console.WriteLine($"{target.ID} health after the attack: {target.GetHealth()}");
    }

public void SetArmor(int armor)
    {
        if (armor > MAX_ARMOR)
            this.armor = MAX_ARMOR;
        else
            this.armor = armor;
    }

    public int GetArmor()
    {
        return armor;
    }

    public void SetAttack(int attack)
    {
        if (attack > MAX_ATTACK)
            this.attack = MAX_ATTACK;
        else
            this.attack = attack;
    }

    public int GetAttack()
    {
        return attack;
    }

    public void ExecuteAttack(Player target)
    {
        Random random = new Random();

        int damageWithoutArmor = this.attack;
        int minimumDamage = 30;
        int maximumDamage = 91 ;
        int damage = random.Next(minimumDamage, maximumDamage); 

        int finalDmg = Math.Max(damageWithoutArmor - target.armor, damage);

        target.health -= finalDmg;

        Console.WriteLine($"{this.ID} dealt {finalDmg} damage to {target.ID}!");
    }

    public bool isDead()
    {
        if (this.health <= 0)
            return true;
        else
            return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Player Player1 = new Player();
        Player Player2 = new Player();
        Player1.InitializePlayer("Player 1",1000,300,100);
        Player2.InitializePlayer("Player 2",1000,300,100);

        while (true)
        {
            Player1.TakeTurn(Player2);

            Player2.TakeTurn(Player1);
        }
    }
}