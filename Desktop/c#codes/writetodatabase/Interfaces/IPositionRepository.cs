public interface IPositionRepository
{
    bool AddPosition(string name, int description);
    bool UpdatePositionName(int id,string name);
    bool UpdatePositionSalary(int id,int salary);
    bool DeletePosition(int id);
    Position GetPositionById(int id);
    List<Position> GetAllPositions();
    List<PositionDetails>GetAllPositionDetails(int id);
}