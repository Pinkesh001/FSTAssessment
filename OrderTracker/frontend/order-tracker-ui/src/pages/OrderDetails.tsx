import { useEffect, useState } from "react";
import { getOrder } from "../api/orderApi";
import type { Order } from "../types/order";
import StatusBadge from "../components/StatusBadge";
import NotesSection from "../components/NotesSection";
import UpdateStatus from "../components/UpdateStatus";

interface Props {
  orderId: string;
  onBack: () => void;
}

const OrderDetails = ({ orderId, onBack }: Props) => {
  const [order, setOrder] = useState<Order | null>(null);
  const [loading, setLoading] = useState(true);

  const fetchOrder = async () => {
    try {
      setLoading(true);
      const data = await getOrder(orderId);
      setOrder(data);
    } catch {
      alert("Failed to fetch order");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchOrder();
  }, []);

  if (loading) return <p>Loading...</p>;
  if (!order) return <p>No order found</p>;

  return (
    <div>
      <button onClick={onBack}>Back</button>
      <h2>Order Details</h2>

      <p>Email: {order.email}</p>
      <p>Mobile: {order.mobile}</p>
      <StatusBadge status={order.status} />

      <h3>Timeline</h3>
      {order.timeline.map((t, i) => (
        <div key={i}>
          {t.status} - {new Date(t.timestamp).toLocaleString()}
        </div>
      ))}

      <UpdateStatus orderId={order.id} refresh={fetchOrder} />
      <NotesSection order={order} refresh={fetchOrder} />
    </div>
  );
};

export default OrderDetails;