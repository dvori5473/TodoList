import axios from 'axios';

const apiClient=axios.create({
  baseURL:process.env.REACT_APP_NOT_API
});
apiClient.interceptors.response.use(function (response) {

  return response;
}, function (error) {
  console.error('API Error:', error.response || error.message);

  return Promise.reject(error);
});
// eslint-disable-next-line import/no-anonymous-default-export
export default {
  getTasks: async () => {
    const result = await apiClient.get('/items')    
    return result.data;
  },

  addTask: async(name)=>{
    const item={Name:name,IsComplete:false}
    console.log('addTask', name)
    const result = await apiClient.post('/items',item)    
    return result.data;
 
  },

  setCompleted: async(id, isComplete)=>{
    console.log('setCompleted', {id, isComplete})
    const result = await apiClient.put(`/items/${id}?isComplete=${isComplete}`,id)    
    return result.data;
  
  },

  deleteTask:async(id)=>{
    console.log('deleteTask',id)
    const result = await apiClient.delete(`/items/${id}`,id)    
    return result.data;
  }
};
