using System;
using System.Threading;

namespace Lab2
{
    class Battle {
        private int timer;
        private bool panz;
        public Battle() {
            this.timer = 0;
        }
        public bool start(Hero hero, Monster monster) {
            if (monster is Dragon) {
                Console.WriteLine("                 /           /                                               ");
                Console.WriteLine("                /' .,,,,  ./                                                 ");
                Console.WriteLine("               /';'     ,/                                                   ");
                Console.WriteLine("              / /   ,,//,`'`                                                 ");
                Console.WriteLine("             ( ,, '_,  ,,,' ``                                               ");
                Console.WriteLine("             |    /@  ,,, ;\" `                                              ");
                Console.WriteLine("            /    .   ,''/' `,``                                              ");
                Console.WriteLine("           /   .     ./, `,, ` ;                                             ");
                Console.WriteLine("        ,./  .   ,-,',` ,,/''\\,'                                            ");
                Console.WriteLine("       |   /; ./,,'`,,'' |   |                                               ");
                Console.WriteLine("       |     /   ','    /    |                                               ");
                Console.WriteLine("       \\___/'   '     |     |                                               ");
                Console.WriteLine("           `,,'  |      /     `\\                                            ");
                Console.WriteLine("               /      |        ~\\                                           ");
                Console.WriteLine("              '       (                                                      ");
                Console.WriteLine("             :                                                               ");
                Console.WriteLine("            ; .         \\--                                                 ");
                Console.WriteLine("          :   \\         ;");
                Thread.Sleep(500);

            }
            if (monster is Skeleton)
            {
                Console.WriteLine("              .7                                                                       ");
                Console.WriteLine("            .'/                                                                        ");
                Console.WriteLine("           / /                                                                         ");
                Console.WriteLine("          / /                                                                          ");
                Console.WriteLine("         / /                                                                           ");
                Console.WriteLine("        / /                                                                            ");
                Console.WriteLine("       / /                                                                             ");
                Console.WriteLine("      / /                                                                              ");
                Console.WriteLine("     / /                                                                               ");
                Console.WriteLine("    / /                                                                                ");
                Console.WriteLine("__ |/                                                                                  ");
                Console.WriteLine(",-\\__\\                                                                               ");
                Console.WriteLine("| f - \"Y\\|                                                                           ");
                Console.WriteLine("\\()7L /                                                                               ");
                Console.WriteLine(" cgD                              __ _                                                   ");
                Console.WriteLine(" |\\(                           .'  Y '>,                                              ");
                Console.WriteLine("  \\ \\                         / _  _   \\                                            ");
                Console.WriteLine("   \\\\\\                        )(_)(_)(|}                                             ");
                Console.WriteLine("    \\\\\\                       {  4A  }  /                                             ");
                Console.WriteLine("     \\\\\\                       \\uLuJJ /\\l                                          ");
                Console.WriteLine("      \\\\\\                      |3    p)/                                            ");
                Console.WriteLine("       \\\\\\___ __________      / nnm_n//                                             ");
                Console.WriteLine("       c7___ - __,__ -)\\,__)(\".  \\_>-<_/D                                           ");
                Console.WriteLine("                            //V     \\_\"-._.__G G_c__.-__<\"/ ( \\                    ");
                Console.WriteLine("                           < \"-._>__-,G_.___)\\    \\7\\                              ");
                Console.WriteLine("                         (\"-.__.| \\\"<.__.-\")       \\ \\                             ");
                Console.WriteLine("                        | \"-.__\"\\  | \"-.__.-\".\\     \\ \\                          ");
                Console.WriteLine("                        (\"-.__\"\". \\\"-.__.-\".|        \\_\\                           ");
                Console.WriteLine("                        \\\"-.__\"\"|!|\" -.__.- \".)       \\ \\                        ");
                Console.WriteLine("                         \"-.__\"\"\\_|\" -.__.- \"./        \\ l                        ");
                Console.WriteLine("                          \".__\"\"\" > G > -.__.- \">       .--,_                     ");
                Console.WriteLine("                              \"\"                                                     ");
                Thread.Sleep(500);
            }
            while (this.timer >= 0) {
                if (this.timer % 2 == 0)
                {
                    this.timer++;
                    heroAction(hero, monster);
                }
                else {
                    this.timer++;
                    monsterAction(monster, hero);
                }
                
            }
            if (this.timer == -1)
            {
                monster.dethe(hero);
                return true;
            }
            else {
                return false;
            }
        }

        public bool start(Hero hero, Chest chest) {
            hero.getExp(chest.outExp());
            return true;
        }
        public void heroAction(Hero hero, Monster monster)
        {
            Console.WriteLine("\nВаш ход\n");
            Thread.Sleep(100);
            Console.WriteLine("\n1. Атаковать мечом\n");
            Thread.Sleep(100);
            Console.WriteLine("\n2. Использовать закдинания\n");
            Thread.Sleep(100);
            Console.WriteLine("\n3. Показать вашу статистику\n");
            Thread.Sleep(100);
            Console.WriteLine("\n4. Показать статистику монстра\n");
            Thread.Sleep(100);
            String s = Console.ReadLine();
            switch (s[0])
            {
                case ('1'):
                    hero.atack(monster);
                    if (monster.getHp() <= 0)
                    {
                        Console.WriteLine("\nВы победили!\n");
                        Thread.Sleep(100);
                        this.timer = -1;
                    }
                    break;
                case ('2'):
                    s = hero.getSpells();
                    if (s.Contains("1"))
                    {
                        Console.WriteLine("\nДоступна медитация(1)\n");
                        Thread.Sleep(100);
                    }
                    if (s.Contains("2"))
                    {
                        Console.WriteLine("\nДоступен Огненный шар(2)\n");
                        Thread.Sleep(100);
                    }
                    if (s.Contains("3"))
                    {
                        Console.WriteLine("\nДоступна заморозка(3)\n");
                        Thread.Sleep(100);
                    }
                    if (s.Contains("4"))
                    {
                        Console.WriteLine("\nДоступна регенирация(4)\n");
                        Thread.Sleep(100);
                    }
                    if (s.Contains("5"))
                    {
                        Console.WriteLine("\nДоступен панцирь(5)\n");
                        Thread.Sleep(100);
                    }
                    s = Console.ReadLine();
                    switch (s[0]) {
                        case ('1'):
                            hero.meditation();
                            break;
                        case ('2'):
                            hero.fireBall(monster);
                            if (monster.getHp() <= 0)
                            {
                                Console.WriteLine("\nВы победили!\n");
                                this.timer = -1;
                            }
                            break;
                        case ('3'):
                            this.timer++;
                            break;
                        case ('4'):
                            hero.regen();
                            break;
                        case ('5'):
                            hero.panz(true);
                            panz = true;
                            break;
                    }
                    break;
                case ('3'):
                    hero.showStats();
                    heroAction(hero, monster);
                    break;
                case ('4'):
                    monster.showStat();
                    heroAction(hero, monster);
                    break;
            }
        }
        public void monsterAction(Monster monster, Hero hero) {
            Console.WriteLine("\nХод противника\n");
            Thread.Sleep(100);
            Console.WriteLine("\nПротивник атакует\n");
            Thread.Sleep(100);
            monster.atack(hero);
            if (hero.getHp() <= 0) {
                Console.WriteLine("\nВы проиграли\n");
                this.timer = -2;
            }
            if (panz) {
                panz = false;
                hero.panz(false);
            }
        }
    }
    class Hero
    {
        private String name;
        private String legend;
        private int hp;
        private int dmg;
        private int dfn;
        private int mana;
        private int lvl;
        private int exp;
        private String spells;

        public Hero(String name) {
            this.name = name;
            this.hp = 20;
            this.dmg = 1;
            this.dfn = 0;
            this.mana = 10;
            this.legend = "";
            this.lvl = 1;
            this.exp = 0;
            this.spells = "4";
        }

        public void showStats() {
            Console.WriteLine("\nЗдоровье: " + this.hp + "\n\nУрон мечом: " + this.dmg + "\n\nМана: " + this.mana);
            if (spells.Contains("1")) {
                Console.WriteLine("\nДоступна медитация\n");
            }
            if (spells.Contains("2")) {
                Console.WriteLine("\nДоступен Огненный шар\n");
            }
            if (spells.Contains("3")) {
                Console.WriteLine("\nДоступна заморозка\n");
            }
            if (spells.Contains("4")) { 
            Console.WriteLine("\nДоступна регенирация\n");
            }
            if (spells.Contains("5")) { 
            Console.WriteLine("\nДоступен панцирь\n");
            }
        }
        public int getHp() {
            return this.hp;
        }
        public void getLegend(String legenf) {
            this.legend += " " + legend;
        }
        public void meditation() {
            this.hp += 5;
            this.mana += 5;
            this.exp += 10;
            checkExp();
        }
        public void panz(bool pa) {
            if (pa)
                this.dfn += 5;
            else
                this.dfn -= 5;
        }
        public String getSpells() {
            return this.spells;
        }
        public void fireBall(Monster monster) {
            if (this.mana >= 3) {
                this.mana -= 3;
                atack(monster, 2*this.lvl);
            }
        }

        public void regen() {
            if (this.mana >= 3) {
                this.mana -= 3;
                this.hp += 20;
            }
        }

        public void checkExp() {
            while (this.exp >= lvl * 25) {
                this.exp -= lvl * 25;
                lvl++;
                lvlUp();
            }
        }

        public void beAtack(int dmg) {
            this.hp -= dmg > this.dfn ? dmg - this.dfn : 0;
        }

        public void atack(Monster monster) {
            monster.beAtack(this.dmg);
        }
        public void atack(Monster monster, int dmg)
        {
            monster.beAtack(dmg);
        }

        public void getExp(int exp) {
            this.exp += exp;
            checkExp();
        }

        public void lvlUp() {
            Console.WriteLine("\nВыбери, что ты хочешь улучшить:\n");
            Console.WriteLine("\n1. Атаку на 1\n");
            Console.WriteLine("\n2. Защиту на 1\n");
            Console.WriteLine("\n3. Изучить новое звклинание\n");
            Console.WriteLine("\n4. Восполнить здоровье на " + (10 + this.lvl) +"\n");
            String s = Console.In.ReadLine();
            switch (s[0])
            {
                case ('1'):
                    this.dmg++;
                    break;
                case ('2'):
                    this.dfn++;
                    break;
                case ('3'):
                    if (!this.spells.Contains("1")) {
                        Console.Write("\nИзучить медитацию? (Увеличит здоровье и ману 5, а также даст 10 опыта)  (1)\n");
                    }
                    if (!this.spells.Contains("2")) {
                        Console.Write("\nИзучить огенный шар? (Нанесет 2*уровнь урона врагу. Стоит 3 маны) (2)\n");
                    }
                    if (!this.spells.Contains("3")) {
                        Console.Write("\nИзучить заморозку? (Пропустит ход противника, стоит 2 маны) (3)\n");
                    }
                    if (!this.spells.Contains("4")) {
                        Console.Write("\nИзучить регенираицию? (Воссатновит 20 здоровья, стоит 3 маны) (4)\n");
                    }
                    if (!this.spells.Contains("5")) {
                        Console.Write("\nИзучить панцирь? (Увеличит защиту на 5 на ход) (5)\n");
                    }
                    this.spells += Console.ReadLine()[0];
                    break;
                case ('4'):
                    this.hp += 10 + this.lvl;
                    break;
                default:
                    break;
            }
        }
    }
    abstract class Monster {
        protected String name;
        protected int hp;
        protected int dmg;
        protected int dfn;
        protected int exp;
        protected int lvl;

        public Monster(String name, int lvl) { }
        public void atack(Hero hero) {
            hero.beAtack(this.dmg);
        }
        public int getHp() {
            return this.hp;
        }
        public void showStat() {
            Console.WriteLine("Имя: " + this.name);
            Thread.Sleep(300);
            Console.WriteLine("\nЗдоровье: " + this.hp);
            Thread.Sleep(300);
            Console.WriteLine("\nУрон: " + this.dmg);
            Thread.Sleep(300);
            Console.WriteLine("\nЗащита: " + this.dfn);
            Thread.Sleep(300);
            Console.WriteLine("\nУровень: " + this.lvl);
            Thread.Sleep(300);
        }
        public void dethe(Hero hero) {
            hero.getExp(this.exp);
        }
        public void beAtack(int dmg)
        {
            this.hp -= dmg > this.dfn ? dmg - this.dfn : 0;
        }
    }
    class Dragon : Monster {
        private String legend;
        public Dragon(String name, int lvl)
            : base(name, lvl)
        {
            this.name = name;
            this.dmg = 4 * lvl;
            this.lvl = lvl;
            this.exp = lvl * 100;
            this.hp = 4 * lvl;
            this.dfn = 2 * lvl;
            this.legend = "";
        }
        public Dragon(String name, int lvl, String legend)
            : base(name, lvl)
        {
            this.name = name;
            this.dmg = 4 * lvl;
            this.lvl = lvl;
            this.exp = lvl * 40;
            this.hp = 4 * lvl;
            this.dfn = lvl;
            this.legend = legend;
        }

        new void dethe(Hero hero) {
            if (!this.legend.Equals("")) {
                Console.Out.WriteLine("Хочешь ли ты взять себе прозвище" + this.legend + "? (y/n)");
                String s = Console.ReadLine();
                if (s.Equals("y")) {
                    hero.getLegend(this.legend);
                }
            }
            hero.getExp(this.exp);
        }
    }
    class Ork : Monster {
        public Ork(String name, int lvl)
            : base(name, lvl) {
            this.name = name;
            this.lvl = lvl;
            this.hp = lvl;
            this.dfn = lvl;
            this.dmg = (int)1.5 * lvl;
            this.exp = lvl * 40;
        }
    }
    class Skeleton : Monster {
        public Skeleton(String name, int lvl)
            : base(name, lvl)
        {
            this.name = name;
            this.lvl = lvl;
            this.hp = lvl;
            this.dfn = (int) 0.5*lvl;
            this.dmg = lvl;
            this.exp = lvl * 25;
        }
        public void death(Hero hero) {
            hero.getExp(this.exp);
        }
    }
    class Chest {
        private int exp;
        public Chest(int exp) {
            this.exp = exp;
        }
        public int outExp() {
            Console.WriteLine("\nВы открыли сундук и нашли там" + this.exp + "опыта\n");
            return this.exp;
        }
        public void show() {
            Console.WriteLine("В данном сундуке содержится опыт\n");
        }
    }
    class Room {
        private Monster monster = null;
        private Battle battle = null;
        private Chest chest = null;
        private bool res = true;
        public Room(Monster monster) {
            this.monster = monster;
            this.battle = new Battle();
        }
        public Room(Chest chest) {
            this.chest = chest;
            this.battle = new Battle();
        }
        public Room(){}
        public bool visit(Hero hero) {
            if (monster == null && chest != null) this.res = this.battle.start(hero, this.chest);
            else if (monster != null && chest == null) this.res = this.battle.start(hero, monster);
            return this.res;
        }
        public void show()
        {
            if (monster == null && chest != null)
            {
                Console.Write("\nВ этой комнате ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Сундук\n");
                Console.ResetColor();
                chest.show();
            }
            else if (monster != null)
            {
                Console.Write("\nВ этой комнате ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Монстр\n");
                Console.ResetColor();
                monster.showStat();
            }
            else {
                Console.Write("\nЭта комнта ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Пуста");
                Console.ResetColor();
            }
            Thread.Sleep(300);
        }
    }
    class Floor {
        Room[] rooms = new Room[3];
        public Floor(Room room1, Room room2, Room room3) {
            this.rooms[0] = room1;
            this.rooms[1] = room2;
            this.rooms[2] = room3;
        }
        public void show()
        {
            for (int i = 0; i < 3; i++) {
                Console.Write("\nКомната номер ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine((i + 1));
                Console.ResetColor();
                Thread.Sleep(300);
                rooms[i].show();
            }
        }
        public bool chose(Hero hero)
        {
            Console.Write("Выберите ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Комнату");
            Console.ResetColor();
            int tmp = Convert.ToInt32(Console.ReadLine());
            return rooms[(tmp-1)].visit(hero);
        }
    }
    class Map {
        int pos;
        Hero hero;
        bool res = true;
        Floor[] floors = new Floor[10];
        public Map(Floor[] floors, Hero hero) {
            this.floors = floors;
            this.pos = 0;
            this.hero = hero;
        }
        public void start() {
            while (res)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nЭтаж " + (pos + 1));
                Console.ResetColor();
                floors[pos].show();
                res = floors[pos].chose(hero);
                pos++;
                if (pos > 9) {
                    Console.WriteLine("Поздравляю! Вы прошли игру!");
                    break;
                }
            }
        }
    }
    class Start {
        /*
    [M][M][C]
    */
        public static Floor floor1() {
            Room room1 = new Room();
            Skeleton skeleton = new Skeleton("Степашка", 1);
            Room room2 = new Room(skeleton);
            Chest chest = new Chest(50);
            Room room3 = new Room(chest);
            Floor floor = new Floor(room1, room2, room3);
            return floor;
        }
        public static Floor floor2() {
            Ork ork = new Ork("Больной на голову", 1);
            Room room1 = new Room(ork);
            Chest chest1 = new Chest(25);
            Room room2 = new Room(chest1);
            Chest chest = new Chest(50);
            Room room3 = new Room(chest);
            Floor floor = new Floor(room1, room2, room3);
            return floor;
        }
        public static Floor floor3() {
            Ork ork = new Ork("Больной на голову старший", 2);
            Room room1 = new Room(ork);
            Skeleton skeleton = new Skeleton("Тощий Стас", 2);
            Room room2 = new Room(skeleton);
            Room room3 = new Room();
            Floor floor = new Floor(room1, room2, room3);
            return floor;
        }
        public static Floor floor4() {
            Skeleton skeleton = new Skeleton("Слава широкая кость", 2);
            Room room1 = new Room(skeleton);
            Chest chest = new Chest(45);
            Room room2 = new Room(chest);
            Room room3 = new Room();
            Floor floor = new Floor(room1, room2, room3);
            return floor;
        }
        public static Floor floor5() {
            Ork ork = new Ork("Буга крепкая башка", 3);
            Room room1 = new Room(ork);
            Chest chest = new Chest(75);
            Room room2 = new Room(chest);
            Skeleton skeleton = new Skeleton("Властилин костей Стас", 4);
            Room room3 = new Room(skeleton);
            Floor floor = new Floor(room1, room2, room3);
            return floor;
        }
        public static Floor floor6() {
            Dragon dragon = new Dragon("Красный дракон",2 , "Драконоборец огня"); 
            Room room1 = new Room(dragon);
            Chest chest = new Chest(55);
            Room room2 = new Room(chest);
            Chest chest1 = new Chest(0);
            Room room3 = new Room(chest);
            Floor floor = new Floor(room1, room2, room3);
            return floor;
        }
        public static Floor floor7() {
            Dragon dragon = new Dragon("Белый дракон", 2, "Драконоборец пурги");
            Room room1 = new Room(dragon);
            Chest chest = new Chest(55);
            Room room2 = new Room(chest);
            Chest chest1 = new Chest(100);
            Room room3 = new Room(chest);
            Floor floor = new Floor(room1, room2, room3);
            return floor;
        }
        public static Floor floor8() {
            Room room1 = new Room(new Skeleton("Вишневй барон", 4));
            Room room2 = new Room(new Ork("Правый палец Грога", 3));
            Room room3 = new Room(new Chest(1000));
            Floor floor = new Floor(room1, room2, room3);
            return floor;
        }
        public static Floor floor9() {
            Ork ork = new Ork("Большая башка Грог", 4);
            Room room1 = new Room(ork);
            Room room2 = new Room(new Chest(50));
            Room room3 = new Room(new Skeleton("Костяной лорд", 5));
            Floor floor = new Floor(room1, room2, room3);
            return floor;
        }
        public static Floor floorBoss() {
            Dragon dragon = new Dragon("Красный дракон", 4, "Драконоборец с красной напастью");
            Room room1 = new Room(dragon);
            Dragon dragon1 = new Dragon("Зеленный дракон", 4, "Драконоборец с зеленой напастью");
            Room room2 = new Room(dragon1);
            Dragon dragon2 = new Dragon("Синий дракон", 4, "Драконоборец с красной напастью");
            Room room3 = new Room(dragon2);
            Floor floor = new Floor(room1, room2, room3);
            return floor;
        }
        public static Map FinalMap(Hero hero)
        {
            Floor[] floors = new Floor[10];
            floors[0] = floor1();
            floors[1] = floor2();
            floors[2] = floor3();
            floors[3] = floor4();
            floors[4] = floor5();
            floors[5] = floor6();
            floors[6] = floor7();
            floors[7] = floor8();
            floors[8] = floor9();
            floors[9] = floorBoss();
            Map map = new Map(floors, hero);
            return map;
        }
        public static void Main() {
            Console.WriteLine("Как тебя зовут, воин?");
            String s = Console.ReadLine();
            Hero hero = new Hero(s);
            Console.WriteLine("Чтож, " + s + ". Чтобы у тебя не было раньше, оставь этот тут. Ты входишь в эту башню. Освободи нас от гнета драконов, дойди до 10 этажа и стань нешем Героем.");
            Map map = FinalMap(hero);
            map.start();
        }
    }
}
