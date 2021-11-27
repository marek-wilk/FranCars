import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

const Vehicles = () => {
  const [vehiclesData, setVehicleData] = useState([]);

  useEffect(() => {
      getVehiclesData();
  }, []);

  async function getVehiclesData() {
    const response = await fetch('http://localhost:18350/vehicle');
    const json = await response.json();
    setVehicleData(json);
  }

  function renderDetailsLinkForLicensed (licensed, vehicleId) {
    if(licensed) {
      return <Link to={`/details/${vehicleId}`}>Details</Link>
    }
    return
  }
  
  return (
    <div>
      <h3>Our cars</h3>
    <table className='table table-striped' aria-labelledby="tableLabel">
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
          <tr key={vehicle.vehicleId}>
            <td>{vehicle.make}</td>
            <td>{vehicle.model}</td>
            <td>{vehicle.yearModel}</td>
            <td>{renderDetailsLinkForLicensed(vehicle.licensed, vehicle.vehicleId)}</td>
          </tr>
        )}
      </tbody>
    </table>
    </div>
  );
};
export default Vehicles;