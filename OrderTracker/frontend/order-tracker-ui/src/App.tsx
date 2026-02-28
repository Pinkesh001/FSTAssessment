import { useState } from "react";
import OrderSearch from "./pages/OrderSearch";
import OrderDetails from "./pages/OrderDetails";

const App = () => {
  const [selectedOrder, setSelectedOrder] = useState<string | null>(null);

  return (
    <div style={{ padding: 20 }}>
      {!selectedOrder ? (
        <OrderSearch onSelect={setSelectedOrder} />
      ) : (
        <OrderDetails
          orderId={selectedOrder}
          onBack={() => setSelectedOrder(null)}
        />
      )}
    </div>
  );
};

export default App;