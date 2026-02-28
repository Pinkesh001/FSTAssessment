import { useState } from "react";
import { searchOrders } from "../api/orderApi";
import type { Order } from "../types/order";

interface Props {
  onSelect: (id: string) => void;
}

const OrderSearch = ({ onSelect }: Props) => {
  const [query, setQuery] = useState("");
  const [orders, setOrders] = useState<Order[]>([]);
  const [loading, setLoading] = useState(false);

  const handleSearch = async () => {
    try {
      setLoading(true);
      const data = await searchOrders(query);
      setOrders(data);
    } catch {
      alert("Search failed");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h2>Order Search</h2>
      <input
        value={query}
        onChange={(e) => setQuery(e.target.value)}
        placeholder="Search by Email, Mobile or OrderId"
      />
      <button onClick={handleSearch}>Search</button>

      {loading && <p>Loading...</p>}

      {orders.map((o) => (
        <div
          key={o.id}
          style={{ border: "1px solid #ddd", margin: 10, padding: 10 }}
          onClick={() => onSelect(o.id)}
        >
          {o.email} | {o.status}
        </div>
      ))}
    </div>
  );
};

export default OrderSearch;