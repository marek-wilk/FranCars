import React, { useState, useEffect } from 'react';

const Vehicles = () => {
  const [vehiclesData, setVehicleData] = useState([]);

  useEffect(() => {
      getVehiclesData();
  });

  async function getVehiclesData() {
    const response = await fetch('http://localhost:18350/vehicle');
    const json = await response.json();
    setVehicleData(json);
  }
  
  return (
    <table className='table table-striped' aria-labelledby="tabelLabel">
      <thead>
        <tr>
          <th>Make</th>
          <th>Model</th>
          <th>Year</th>
          <th></th>
      </tr>
      </thead>
      <tbody>
        {vehiclesData.map(vehicle =>
          <tr key={vehicle.dateAdded}>
            <td>{vehicle.make}</td>
            <td>{vehicle.model}</td>
            <td>{vehicle.year}</td>
          </tr>
        )}
      </tbody>
    </table>
  );
};
export default Vehicles;