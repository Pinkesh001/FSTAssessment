import { useState } from "react";
import { updateStatus } from "../api/orderApi";

interface Props {
  orderId: string;
  refresh: () => void;
}

const UpdateStatus = ({ orderId, refresh }: Props) => {
  const [status, setStatus] = useState("PLACED");
  const [loading, setLoading] = useState(false);

  const handleUpdate = async () => {
    try {
      setLoading(true);
      await updateStatus(orderId, status);
      refresh();
    } catch {
      alert("Invalid status transition");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Update Status</h3>
      <select value={status} onChange={(e) => setStatus(e.target.value)}>
        <option>PLACED</option>
        <option>PAID</option>
        <option>SHIPPED</option>
        <option>DELIVERED</option>
        <option>CANCELLED</option>
      </select>
      <button onClick={handleUpdate} disabled={loading}>
        {loading ? "Updating..." : "Update"}
      </button>
    </div>
  );
};

export default UpdateStatus;