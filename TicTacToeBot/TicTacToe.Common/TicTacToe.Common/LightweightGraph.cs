using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Common
{
    [Serializable()]
    public class LightweightGraph<V>
    {

        /***************************************************************************
         *	CONSTANTS
         **************************************************************************/

        /** Weight value of non-existent path between two Vertexes */
        public static double PATH_DOES_NOT_EXIST = -999.0;


        /***************************************************************************
         *	ATTRIBUTES
         **************************************************************************/

        /** HashMap for underlying storage of items */
        private Dictionary<V, Vertex<V>> theItems;
        public bool IsEmpty { get { return theItems.Count == 0; } }
        public int Size { get { return theItems.Count; } }

        /***************************************************************************
         *	CONSTRUCTORS
         **************************************************************************/

        public LightweightGraph()
        {
            // empty this LightweightGraph
            Clear();
        }



        /***************************************************************************
         *	METHODS
         **************************************************************************/

        /**
         *	Return whether this LightweightGraph contains the specified item.
         *
         *	@param	item	the item being searched for
         *
         *	@return			true if this LightweightGraph contains the specified item
         *					false if this LightweightGraph does not contain the specified item
         */
        public bool Contains(V item)
        {
            return theItems.ContainsKey(item);
        }


        /**
         *	Add an item to this LightweightGraph.
         *	If the specified item already exists, this LightweightGraph is not modified
         *
         *	@param	item	the item to be added
         */
        public void Add(V item)
        {
            if (!this.Contains(item))
            {
                theItems.Add(item, new Vertex<V>(item));
            }
        }


        /**
         *	Add a unidirectional Edge between the specified origin and destination items, with the
         *	specified weight. If either the origin or destination items do not exist, they will be
         *	created. If an Edge already exists between the origin and the destination, no new Edge
         *	will be created, and the existing Edge will be preserved.
         *
         *	@param	origin			the item from which the Edge will leave
         *	@param	destination		the item to which the Edge will go
         *	@param	weight			the weight to be assigned to the Edge
         */
        public void AddEdge(V origin, V destination, double weight)
        {
            Vertex<V> originVertex = theItems.ContainsKey(origin) ? theItems[origin] : null;
            Vertex<V> destinationVertex = theItems.ContainsKey(destination) ? theItems[destination] : null;

            if (originVertex == null)
            {
                originVertex = new Vertex<V>(origin);
                theItems.Add(origin, originVertex);
            }

            if (destinationVertex == null)
            {
                destinationVertex = new Vertex<V>(destination);
                theItems.Add(destination, destinationVertex);
            }

            if (!destinationVertex.IsAdjacentTo(originVertex))
            {
                originVertex.AddDestination(new Edge<V>(destinationVertex, weight));
            }
        }


        /**
         *	Update the weight of an existing unidirectional Edge between the specified origin and
         *	destination items, with the specified weight increment/decrement. If either the origin
         *	or destination items do not exist, or if the destination is not adjacent to the origin,
         *	no update will be made.
         *
         *	@param	origin			the item from which the Edge leaves
         *	@param	destination		the item to which the Edge goes
         *	@param	weight			the value by which the Edge will be incremented/decremented
         */
        public void UpdateEdgeWeight(V origin, V destination, double weight)
        {
            Vertex<V> originVertex = theItems[origin];
            Vertex<V> destinationVertex = theItems[destination];

            if (originVertex != null && destinationVertex != null && destinationVertex.IsAdjacentTo(originVertex))
            {
                Edge<V> existingEdge = originVertex.GetEdge(destination);

                if (existingEdge.weight + weight >= Double.NegativeInfinity &&
                        existingEdge.weight + weight <= Double.PositiveInfinity)
                {
                    existingEdge.weight += weight;
                }
            }
        }


        /**
         *	Return the specified item.
         *
         *	@return		the specified item, if it exists
         *				null if specified item doesn't exist
         */
        public V Get(V item)
        {
            return theItems.Keys.FirstOrDefault(v => v.Equals(item));

        }


        /**
         *	Return the weight of the path between the specifies origin and destination items.
         *
         *	@param	origin			the item from which the path leads
         *	@param	destination		the item to which the path goes
         *
         *	@return					weight of the path from origin to destination, if path exists
         *							PATH_DOES_NOT_EXIST if path is not existent, or if either the
         *								origin or destination items do not exist
         */
        public double GetWeightBetweenAdjacentItems(V origin, V destination)
        {
            double weight = PATH_DOES_NOT_EXIST;

            Vertex<V> originVertex = theItems.ContainsKey(origin) ? theItems[origin] : null;

            if (originVertex != null)
            {
                Edge<V> edge = originVertex.GetEdge(destination);

                if (edge != null)
                {
                    return edge.weight;
                }
            }

            return weight;
        }


        /**
         *	Internal method for retrieving the Vertex containing the specified item.
         *
         *	@param	item	the item being searched for
         *
         *	@return			the Vertex containing item, if item exists in this LightweightGraph
         *					null, if item does not exist
         */
        private Vertex<V> GetVertex(V item)
        {
            return theItems[item];
        }


        /**
         *	Return a list of items in this LightweightGraph.
         *
         *	@return		a List of size > 0 containing the items present in this LightweightGraph
         *				an empty List if this LightweightGraph is empty
         */
        public List<V> GetItems()
        {
            return theItems.Keys.ToList();
        }


        /**
         *	Return a list of items adjacent to the specified item.
         *
         *	@param	item	the item
         *
         *	@return			a List of size >0 containing the items adjacent to the specified item
         *					an empty List if there are no items adjacent to the specified item
         */
        public List<V> GetAdjacentItems(V item)
        {
            List<V> adjacentItems = new List<V>();

            Vertex<V> itemVertex = theItems[item];

            if (itemVertex != null)
            {
                adjacentItems = itemVertex.adjacencyList.Select(e => e.destination.theItem).ToList();
            }

            return adjacentItems;
        }


        /**
         *	Empty this LightweightGraph.
         */
        public void Clear()
        {
            // reset underlying HashMap
            theItems = new Dictionary<V, Vertex<V>>();
        }


        /**
         *	Return a String representation of this ListGraph
         */
        public override String ToString()
        {
            StringBuilder result = new StringBuilder("");

            foreach (var item in theItems.Values)
            {
                result = result.Append(item.ToString() + "\n");
            }

            return result.ToString();
        }


        /***************************************************************************
         *	INNER CLASSES
         **************************************************************************/

        /**
         *	Inner class Vertex. This class represents a node in a graph.
         */
        [Serializable()]
        internal class Vertex<V>
        {
            /***********************************************************************
             *	ATTRIBUTES
             **********************************************************************/

            /** The data item stored in this Vertex */
            internal V theItem;

            /** List of vertices adjacent to this Vertex */
            internal List<Edge<V>> adjacencyList;

            /** Distance to this Vertex */
            internal double distance;


            /***********************************************************************
             *	CONSTRUCTORS
             **********************************************************************/

            /**
             *	Create a new Vertex containing the specified item.
             *	The newly created Vertex will have no adjacent vertices
             *	
             *	@param	item	the data item contained in this Vertex
             */
            public Vertex(V item)
            {
                // store item
                theItem = item;

                // create adjacency list
                adjacencyList = new List<Edge<V>>();
            }


            /***********************************************************************
             *	METHODS
             **********************************************************************/

            /**
             *	Return this Vertex's list of adjacent vertices.
             *
             *	The adjacent vertices are encapsulated in Edge objects.
             */
            private List<Edge<V>> GetAdjacentVertices()
            {
                return adjacencyList;
            }


            /**
             *	Return this Vertex's list of adjacent items.
             *
             *	Returns an empty List if this Vertex has no adjacent vertices
             */
            public List<V> GetAdjacentItems()
            {
                // List for storing adjacent items
                List<V> adjacentItems = new List<V>();

                // traverse adjacency list of this Vertex and place items of all
                // adjacent vertices into adjacent items list
                foreach (var e in adjacencyList)
                {
                    adjacentItems.Add(e.destination.theItem);
                }

                return adjacentItems;
            }


            /**
             *	Add the specified Edge to this Vertex's adjacency list.
             *
             *	Returns true if Edge was successfully added, false otherwise.
             */
            public bool AddDestination(Edge<V> e)
            {
                adjacencyList.Add(e);

                return true;
            }


            /**
             *	Return whether this Vertex is adjacent to the specified predecessor Vertex.
             *
             *	@param	predecessor		the predecessor Vertex
             *
             *	@return					true, if this Vertex is in the adjacency list of predecessor
             *							false, if this Vertex is not in the adjacency list of predecessor
             */
            public bool IsAdjacentTo(Vertex<V> predecessor)
            {
                return predecessor.GetEdge(this.theItem) != null;
            }


            /**
             *	Internal method for retrieving from the adjacency list the Edge with
             *	the specified item. 
             *
             *	@param	item	the item whose Edge is needed
             *
             *	@return			the Edge to a Vertex containing item, if it is in the adjacency list
             *					null if no Edge in the adjacency list points to a Vertex containing item
             */
            internal Edge<V> GetEdge(V item)
            {
                // search adjacency list for an Edge containing a Vertex containing obj
                return adjacencyList.FirstOrDefault(e => e.destination.theItem.Equals(item));
            }


            /***********************************************************************
             *	METHODS INHERITED FROM CLASS OBJECT
             **********************************************************************/

            /**
             *	Return whether the specified Vertex equals this Vertex.
             *	Two vertices are considered equal if they contain the same item.
             *
             *	@param	otherVertex		othe Vertex to compare to
             */
            public bool Equals(Vertex<V> otherVertex)
            {
                return this.theItem.Equals(otherVertex.theItem);
            }


            /**
             *	Return a String representation of this Vertex.
             */
            public override String ToString()
            {
                StringBuilder result = new StringBuilder(theItem == null ? "null" : theItem.ToString() + ":\n");

                result.Append("Destinations:\n");

                foreach (var edge in adjacencyList)
                {
                    result.Append(edge.toString() + "\n");
                }

                return result.ToString();
            }
        }


        /**
         *	Inner class Edge
         *
         *	This class represents an edge connecting two vertices in a graph. An Edge
         *	contains a reference to a destination Vertex, and a numeric edge weight.
         */
        [Serializable()]
        internal class Edge<V>
        {

            /***********************************************************************
             *	ATTRIBUTES
             **********************************************************************/

            /** This Edge's destination Vertex */
            internal Vertex<V> destination;

            /** Weight associated with this Edge */
            internal double weight;


            /***********************************************************************
             *	CONSTRUCTORS
             **********************************************************************/

            /**
             *	Create a new Edge with the specified destination Vertex and the
             *	specified weight.
             */
            public Edge(Vertex<V> dest, double weight)
            {
                destination = dest;
                this.weight = weight;
            }


            /***********************************************************************
             *	METHODS INHERITED FROM CLASS OBJECT
             **********************************************************************/

            /**
             *	Return a String representation of this Edge.
             */
            public String toString()
            {
                return (destination == null ? "null" : destination.theItem.ToString() + " (weight = " + weight + ")");
            }


            /**
             *	Return whether the specified Edge equals this Edge.
             *
             *	Two edges are considered equal if they have the same destination
             *	and the same weight.
             */
            public bool equals(Edge<V> otherEdge)
            {
                return (weight == otherEdge.weight) && destination.Equals(otherEdge.destination);
            }
        }
    }

}
