/// <summary>
/// 駒の移動ルールの表現
/// </summary>
public class Movable{
    public int x;
    public int y;
    public bool isAny;   //その方向に何マスでも移動可能かどうか

    public Movable(int x, int y, bool isAny) {
        this.x = x;
        this.y = y;
        this.isAny = isAny;
    }
}
