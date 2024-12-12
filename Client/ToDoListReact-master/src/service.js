import axios from 'axios';

const apiUrl = process.env.REACT_APP_NOT_SECRET_CODE
//const apiUrl = "http://localhost:5262"

export default {
  getTasks: async () => {
    const result = await axios.get(`${apiUrl}/items`)    
    return result.data;
  },

  addTask: async(name)=>{
    const item={Name:name,IsComplete:false}
    console.log('addTask', name)
    const result = await axios.post(`${apiUrl}/items`,item)    
    return result.data;
 
  },

  setCompleted: async(id, isComplete)=>{
    console.log('setCompleted', {id, isComplete})
    const result = await axios.put(`${apiUrl}/items/${id}?isComplete=${isComplete}`,id)    
    return result.data;
  
  },

  deleteTask:async(id)=>{
    console.log('deleteTask',id)
    const result = await axios.delete(`${apiUrl}/items/${id}`,id)    
    return result.data;
  }
};
