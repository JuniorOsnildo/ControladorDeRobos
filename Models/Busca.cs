namespace ControladorDeRobos.Models;

public class Busca
{
    private List<Nodo> Nodes = [];
    private List<List<Nodo>> ChildrenLists = [];

    public void AddNodo(Nodo nodo)
    {
        if (Nodes.Count > 0)
            throw new InvalidOperationException("A arvore ja tem ráiz");
        
        Nodes.Add(nodo);
        ChildrenLists.Add(new List<Nodo>());
    }

}