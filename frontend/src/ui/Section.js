import styled from "styled-components";

const Section = styled.section`
  width: 800px;
  margin: auto;
  display: flex;
  align-items: ${props => props.alignItems};
  justify-content: ${props => props.justifyContent};
  flex-flow: wrap row;

  @media (min-width: 600px) {
    width: 600px;
    margin: auto;
  }
`;

export default Section;
