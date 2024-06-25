namespace Figures;

// Добалять фигуры легко, достаточно добавить очередного наследника
// Благодаря полиморфизму можно вычислить площадь без знания типа фигуры
public interface IFigure
{
    double CalculateArea();
}