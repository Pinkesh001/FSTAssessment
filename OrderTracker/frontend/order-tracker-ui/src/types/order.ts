export interface OrderNote {
  author: string;
  message: string;
  createdAt: string;
}

export interface OrderTimeline {
  status: string;
  timestamp: string;
}

export interface Order {
  id: string;
  email: string;
  mobile: string;
  status: string;
  notes: OrderNote[];
  timeline: OrderTimeline[];
}